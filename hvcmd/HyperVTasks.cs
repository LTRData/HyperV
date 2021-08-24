using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LTR.HyperV
{
    using Management.ROOT.virtualization.v2;

    public static class HyperVTasks
    {
#if NET46_OR_GREATER || NETSTANDARD || NETCOREAPP
        internal static readonly string[] EmptyStringArray = Array.Empty<string>();
#else
        internal static readonly string[] EmptyStringArray = new string[0];
#endif

        public static async Task<uint> ChangeState(ManagementScope scope, string machineName, VirtualMachineState newState, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var machine = HyperVSupportRoutines.GetTargetComputer(scope, machineName) ??
                throw new Exception("Virtual machine not found.");

            return await machine.ChangeState(newState, jobProgress, cancellationToken);
        }

        public static Task<uint> ChangeState(this ComputerSystem machine, VirtualMachineState newState, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            var result = machine.RequestStateChange((ushort)newState, null, out var jobPath);

            return CompleteJob(result, jobPath, jobProgress, cancellationToken);
        }

        public static Task<uint> Shutdown(ManagementScope scope, string machineName, bool forceShutdown)
        {
            using var machine = HyperVSupportRoutines.GetTargetComputer(scope, machineName) ??
                throw new Exception("Virtual machine not found.");

            using var shutdownComponent = HyperVSupportRoutines.GetShutdownComponent(machine) ??
                throw new Exception("Virtual machine cannot shut down.");

            var result = shutdownComponent.InitiateShutdown(forceShutdown, "Initiated by hvcmd.exe");

            return Task.FromResult(result);
        }

        public static Func<ConcreteJob, CancellationToken, Task> CreateJobProgressRoutine(Action<ConcreteJob, CancellationToken> action, int millisecondInterval) =>
            (job, cancellationToken) =>
            {
                action(job, cancellationToken);

                if ((JobState)job.JobState == JobState.Starting
                    || (JobState)job.JobState == JobState.Running)
                {
                    return Task.Delay(millisecondInterval, cancellationToken);
                }
                else
                {
                    return Task.FromResult(0);
                }
            };

        public static Func<ConcreteJob, CancellationToken, Task> CreateJobProgressRoutine(Action<ConcreteJob> action, int millisecondInterval) =>
            (job, cancellationToken) =>
            {
                action(job);

                if ((JobState)job.JobState == JobState.Starting
                    || (JobState)job.JobState == JobState.Running)
                {
                    return Task.Delay(millisecondInterval, cancellationToken);
                }
                else
                {
                    return Task.FromResult(0);
                }
            };

        public static async Task<uint> DestroyVM(ManagementScope scope, string machineName, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var machine = HyperVSupportRoutines.GetTargetComputer(scope, machineName) ??
                throw new Exception("Virtual machine not found.");

            return await DestroyVM(machine, jobProgress, cancellationToken);
        }

        public async static Task<uint> DestroyVM(this ComputerSystem machine, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var virtSysMgmtSvc = HyperVSupportRoutines.GetVirtualSystemManagementService(machine.Scope);

            var result = virtSysMgmtSvc.DestroySystem(machine.Path, out var jobPath);

            return await CompleteJob(result, jobPath, jobProgress, cancellationToken);
        }

        public static async Task<ComputerSystem> CreateVM(ManagementScope scope, string name, VMGeneration generation, string configuration_version, long? memory_mb, int? vcpus, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            // Obtain controller for Hyper-V virtualization subsystem
            using var vmMgmtSvc = HyperVSupportRoutines.GetVirtualSystemManagementService(scope);

            // Create VM with correct name and default resources
            var machine = await vmMgmtSvc.CreateDefaultVM(name, generation, configuration_version, jobProgress, cancellationToken);

            // Update the resource settings for the VM.

            var resourceSettings = new List<string>();

            // Resource settings are referenced through the Msvm_VirtualSystemSettingData object.
            using var vmSettings = machine.GetVMSystemSettingsData();

            if (memory_mb.HasValue)
            {
                // For memory settings, there is no Dynamic Memory, so reservation, limit and quantity are identical.
                using var memSettings = vmSettings.GetMemSettings();
                memSettings.LateBoundObject["VirtualQuantity"] = memory_mb;
                memSettings.LateBoundObject["Reservation"] = memory_mb;
                memSettings.LateBoundObject["Limit"] = memory_mb;
                resourceSettings.Add(memSettings.LateBoundObject.GetText(TextFormat.CimDtd20));
            }

            if (vcpus.HasValue)
            {
                // Update the processor settings for the VM, static assignment of 100% for CPU limit
                using var procSettings = vmSettings.GetProcSettings();
                procSettings.LateBoundObject["VirtualQuantity"] = vcpus;
                procSettings.LateBoundObject["Reservation"] = vcpus;
                procSettings.LateBoundObject["Limit"] = 100000;
                resourceSettings.Add(procSettings.LateBoundObject.GetText(TextFormat.CimDtd20));
            }

            if (resourceSettings.Count > 0)
            {
                var result = vmMgmtSvc.ModifyResourceSettings(
                    resourceSettings.ToArray(),
                    out var jobPath,
                    out _);

                result = await CompleteJob(result, jobPath, jobProgress, cancellationToken);

                if ((ReturnCode)result != ReturnCode.Completed)
                {
                    throw new Exception($"Failed modifying VM, error code: {result}");
                }
            }

            return machine;
        }
        
        private static async Task<ComputerSystem> CreateDefaultVM(this VirtualSystemManagementService vmMgmtSvc, string name, VMGeneration generation, string configuration_version, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            // Tweak default settings by basing new VM on default global setting object 
            // with designed display name.
            ushort startupAction = 2; // Do nothing.
            ushort stopAction = 4; // Shutdown.

            using var vs_gs_data = VirtualSystemSettingData.CreateInstance(vmMgmtSvc.Scope);

            if (!string.IsNullOrWhiteSpace(configuration_version))
            {
                vs_gs_data.LateBoundObject["Version"] = configuration_version;
            }

            vs_gs_data.LateBoundObject["ElementName"] = name;
            vs_gs_data.LateBoundObject["AutomaticStartupAction"] = startupAction.ToString();
            vs_gs_data.LateBoundObject["AutomaticShutdownAction"] = stopAction.ToString();
            vs_gs_data.LateBoundObject.SetPropertyValueIfExists("AutomaticSnapshotsEnabled", false);

            if (generation != VMGeneration.G1)
            {
                vs_gs_data.LateBoundObject["VirtualSystemSubtype"] = $"Microsoft:Hyper-V:SubType:{(int)generation}";
            }

            vs_gs_data.LateBoundObject["Notes"] = new[] { "Created by hvcmd.exe\n" };

            var result = vmMgmtSvc.DefineSystem(
                null,
                EmptyStringArray,
                vs_gs_data.LateBoundObject.GetText(TextFormat.CimDtd20),
                out var jobPath,
                out var defined_sys);

            result = await CompleteJob(result, jobPath, jobProgress, cancellationToken);

            if ((ReturnCode)result != ReturnCode.Completed)
            {
                throw new Exception($"Failed creating VM, error code: {result}");
            }

            if (defined_sys != null)
            {
                var machine = new ComputerSystem(defined_sys);

                // Assertion
                if (!machine.ElementName.Equals(name, StringComparison.Ordinal))
                {
                    var errMsg = $"New VM created with wrong name (is {machine.ElementName}, should be {name}, GUID {machine.Name})";

                    throw new Exception(errMsg);
                }

                return machine;
            }

            return HyperVSupportRoutines.GetTargetComputer(vmMgmtSvc.Scope, name);
        }

        public static async Task<ResourceAllocationSettingData> CreateSCSIforVM(this ComputerSystem machine, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            // Obtain controller for Hyper-V networking subsystem
            using var scsiTemplate = HyperVSupportRoutines.GetResourceTemplate(machine.Scope, ResourceSubType.ControllerSCSI);

            // Create SCSI resource by cloning the default SCSI
            using var newSynthSCSISettings = new ResourceAllocationSettingData((ManagementBaseObject)scsiTemplate.LateBoundObject.Clone());

            //  Assign configuration to new SCSI
            newSynthSCSISettings.LateBoundObject["ElementName"] = "SCSI Controller";
            newSynthSCSISettings.CommitObject();

            // Insert SCSI into vm
            var newResources = new[] { newSynthSCSISettings.LateBoundObject.GetText(TextFormat.CimDtd20) };

            using var virtSysMgmtSvc = HyperVSupportRoutines.GetVirtualSystemManagementService(machine.Scope);

            var result = virtSysMgmtSvc.AddResourceSettings(machine.Path, newResources, out var jobPath, out var newResourcePaths);

            result = await CompleteJob(result, jobPath, jobProgress, cancellationToken);

            if ((ReturnCode)result != ReturnCode.Completed)
            {
                throw new Exception($"Failed adding network interface to virtual machine. Error code: {result}");
            }
            
            if (newResourcePaths == null)
            {
                throw new Exception($"Created SCSI controller not returned.");
            }

            return new ResourceAllocationSettingData(newResourcePaths[0]);
        }

        public static async Task<SyntheticEthernetPortSettingData> CreateNICforVM(this ComputerSystem machine, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            // Create NIC resource by cloning the default NIC 
            var synthNICsSettings = SyntheticEthernetPortSettingData.GetInstances(machine.Scope, "InstanceID LIKE \"%Default\"");

            using var defaultSynthNICSettings = synthNICsSettings.OfType<SyntheticEthernetPortSettingData>().First();

            using var newSynthNICSettings = new SyntheticEthernetPortSettingData((ManagementBaseObject)defaultSynthNICSettings.LateBoundObject.Clone());

            //  Assign configuration to new NIC
            newSynthNICSettings.LateBoundObject["ElementName"] = "VMBus NIC";
            newSynthNICSettings.LateBoundObject["VirtualSystemIdentifiers"] = new[] { Guid.NewGuid().ToString("b") };
            newSynthNICSettings.CommitObject();

            // Insert NIC into vm
            var newResources = new[] { newSynthNICSettings.LateBoundObject.GetText(TextFormat.CimDtd20) };

            using var virtSysMgmtSvc = HyperVSupportRoutines.GetVirtualSystemManagementService(machine.Scope);

            var result = virtSysMgmtSvc.AddResourceSettings(machine.Path, newResources, out var jobPath, out var newResourcePaths);

            result = await CompleteJob(result, jobPath, jobProgress, cancellationToken);

            if ((ReturnCode)result != ReturnCode.Completed)
            {
                throw new Exception($"Failed adding network interface to virtual machine. Error code: {result}");
            }

            if (newResourcePaths == null)
            {
                throw new Exception($"Created NIC not returned.");
            }

            return new SyntheticEthernetPortSettingData(newResourcePaths[0]);
        }

        public static async Task<EmulatedEthernetPortSettingData> CreateEmulatedNICforVM(this ComputerSystem machine, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            // Create NIC resource by cloning the default NIC 
            var synthNICsSettings = EmulatedEthernetPortSettingData.GetInstances(machine.Scope, "InstanceID LIKE \"%Default\"");

            using var defaultSynthNICSettings = synthNICsSettings.OfType<EmulatedEthernetPortSettingData>().First();

            using var newSynthNICSettings = new EmulatedEthernetPortSettingData((ManagementBaseObject)defaultSynthNICSettings.LateBoundObject.Clone());

            //  Assign configuration to new NIC
            newSynthNICSettings.LateBoundObject["ElementName"] = "Emulated NIC";
            newSynthNICSettings.CommitObject();

            // Insert NIC into vm
            var newResources = new[] { newSynthNICSettings.LateBoundObject.GetText(TextFormat.CimDtd20) };

            using var virtSysMgmtSvc = HyperVSupportRoutines.GetVirtualSystemManagementService(machine.Scope);

            var result = virtSysMgmtSvc.AddResourceSettings(machine.Path, newResources, out var jobPath, out var newResourcePaths);

            result = await CompleteJob(result, jobPath, jobProgress, cancellationToken);

            if ((ReturnCode)result != ReturnCode.Completed)
            {
                throw new Exception($"Failed adding network interface to virtual machine. Error code: {result}");
            }

            if (newResourcePaths == null)
            {
                throw new Exception($"Created emulated NIC not returned.");
            }

            return new EmulatedEthernetPortSettingData(newResourcePaths[0]);
        }

        internal async static Task<uint> CreateSCSIforVM(ManagementScope scope, string machineName, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var machine = HyperVSupportRoutines.GetTargetComputer(scope, machineName) ??
                throw new Exception("Virtual machine not found.");

            await CreateSCSIforVM(machine, jobProgress, cancellationToken);

            return 0;
        }

        public static Task<uint> CreateEthernetPrivateSwitch(ManagementScope scope, string name, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken) =>
            CreateEthernetSwitch(scope, name, null, jobProgress, cancellationToken);

        public static Task<uint> CreateEthernetExternalOnlySwitch(ManagementScope scope, string name, string adapter_name, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken) =>
            CreateEthernetSwitch(scope, name, new[] { HyperVSupportRoutines.CreateExternalEthernetPort(scope, $"{name}_ExternalPort", adapter_name) }, jobProgress, cancellationToken);

        public static Task<uint> CreateEthernetExternalSwitch(ManagementScope scope, string name, string adapter_name, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken) =>
            CreateEthernetSwitch(scope, name, new[] { HyperVSupportRoutines.CreateExternalEthernetPort(scope, $"{name}_ExternalPort", adapter_name), HyperVSupportRoutines.CreateInternalEthernetPort(scope, $"{name}_InternalPort") }, jobProgress, cancellationToken);

        public static Task<uint> CreateEthernetInternalSwitch(ManagementScope scope, string name, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken) =>
            CreateEthernetSwitch(scope, name, new[] { HyperVSupportRoutines.CreateInternalEthernetPort(scope, $"{name}_InternalPort") }, jobProgress, cancellationToken);

        public async static Task<uint> CreateEthernetSwitch(ManagementScope scope, string name, EthernetPortAllocationSettingData[] ports, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var settings = VirtualEthernetSwitchSettingData.CreateInstance(scope);
            settings.LateBoundObject["ElementName"] = name;
            var switch_setting_text = settings.LateBoundObject.GetText(TextFormat.WmiDtd20);

            // Obtain controller for Hyper-V networking subsystem
            using var sw_mgmt_svc = HyperVSupportRoutines.GetVirtualSwitchManagementService(scope);

            string[] ports_text = null;

            if (ports != null)
            {
                ports_text = Array.ConvertAll(ports, port => port.LateBoundObject.GetText(TextFormat.WmiDtd20));
            }

            var result = sw_mgmt_svc.DefineSystem(null, ports_text, switch_setting_text, out var jobPath, out var resulting_switch_path);

            result = await CompleteJob(result, jobPath, jobProgress, cancellationToken);

            return result;
        }

        public async static Task<uint> AttachVMToSwitch(this ComputerSystem machine, ManagementPath adapter, VirtualEthernetSwitch vswitch, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var default_settings = EthernetPortAllocationSettingData.GetInstances(machine.Scope, "InstanceID LIKE \"%Default\"").OfType<EthernetPortAllocationSettingData>().First();
            using var settings = new EthernetPortAllocationSettingData((ManagementBaseObject)default_settings.LateBoundObject.Clone());

            settings.LateBoundObject["Parent"] = adapter.Path;
            settings.LateBoundObject["HostResource"] = new[] { vswitch.Path.Path };

            using var mgmtsvc = HyperVSupportRoutines.GetVirtualSystemManagementService(machine.Scope);

            // Resource settings are referenced through the Msvm_VirtualSystemSettingData object.
            using var vmsettings = machine.GetVMSystemSettingsData();

            var result = mgmtsvc.AddResourceSettings(vmsettings.Path, new[] { settings.LateBoundObject.GetText(TextFormat.WmiDtd20) }, out var jobPath, out var results);

            result = await CompleteJob(result, jobPath, jobProgress, cancellationToken);

            return result;
        }

        public static async Task<uint> AttachPhysicalDisk(this ComputerSystem machine, ResourceAllocationSettingData controller, DiskDrive physicalDisk, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var newDiskDriveSettings = HyperVSupportRoutines.GetPHDTemplate(machine.Scope);
            var moManagementService = HyperVSupportRoutines.GetVirtualSystemManagementService(machine.Scope);

            newDiskDriveSettings.LateBoundObject["Parent"] = controller.Path.ToString();
            newDiskDriveSettings.LateBoundObject["HostResource"] = new[] { physicalDisk.Path.Path };
            newDiskDriveSettings.CommitObject();

            var newDriveResource = new[] { newDiskDriveSettings.LateBoundObject.GetText(TextFormat.CimDtd20) };

            var result = moManagementService.AddResourceSettings(machine.Path, newDriveResource, out var job, out var resultResources);

            return await CompleteJob(result, job, jobProgress, cancellationToken);
        }

        public async static Task<uint> SetVMSystemSettingsData(this VirtualSystemSettingData settings, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var service = HyperVSupportRoutines.GetVirtualSystemManagementService(settings.Scope);

            var result = service.ModifySystemSettings(settings.LateBoundObject.GetText(TextFormat.CimDtd20), out var job);

            return await CompleteJob(result, job, jobProgress, cancellationToken);
        }

        public async static Task<uint> SetVMResourceSettingsData(ManagementScope scope, ManagementBaseObject[] settings, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var service = HyperVSupportRoutines.GetVirtualSystemManagementService(scope);

            var result = service.ModifyResourceSettings(Array.ConvertAll(settings, setting => setting.GetText(TextFormat.CimDtd20)), out var job, out var results);

            return await CompleteJob(result, job, jobProgress, cancellationToken);
        }

        public static async Task<uint> AddPhysicalDisk(ManagementScope scope, string machineName, string controllerType, int controllerNumber, int? driveNumber, int hostDriveNumber, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var machine = HyperVSupportRoutines.GetTargetComputer(scope, machineName) ??
                throw new Exception("Virtual machine not found.");

            return await AddPhysicalDisk(machine, controllerType, controllerNumber, driveNumber, hostDriveNumber, jobProgress, cancellationToken);
        }

        public static Task<uint> AddPhysicalDisk(this ComputerSystem machine, string controllerType, int controllerNumber, int? driveNumber, int hostDriveNumber, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var hostDrive = HyperVSupportRoutines.GetHostDiskDrive(machine.Scope, hostDriveNumber) ??
                throw new Exception($"Cannot find drive number {hostDriveNumber} on host. Please verify that the disk is attached and is in offline mode.");

            return AddDriveWithMedia(machine, controllerType, controllerNumber, driveNumber, ResourceSubType.DiskPhysical, hostDrive.Path.Path, jobProgress, cancellationToken);
        }

        public static async Task<uint> AddDriveWithMedia(ManagementScope scope, string machineName, string controllerType, int controllerNumber, int? driveNumber, string storageType, string hostResourcePath, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var machine = HyperVSupportRoutines.GetTargetComputer(scope, machineName) ??
                throw new Exception("Virtual machine not found.");

            return await AddDriveWithMedia(machine, controllerType, controllerNumber, driveNumber, storageType, hostResourcePath, jobProgress, cancellationToken);
        }

        public static async Task<uint> AddDriveWithMedia(this ComputerSystem machine, string controllerType, int controllerNumber, int? driveNumber, string storageType, string hostResourcePath, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var device = machine.GetController(controllerType, controllerNumber) ??
                throw new Exception("Controller not found.");

            using var drive = HyperVSupportRoutines.GetResourceTemplate(machine.Scope, storageType);
            using var managementService = HyperVSupportRoutines.GetVirtualSystemManagementService(machine.Scope);

            if (device == null || drive == null || managementService == null)
                throw new Exception("Device or controller management not accessible.");

            drive.LateBoundObject["Parent"] = device.Path.Path;

            if (driveNumber.HasValue)
                drive.LateBoundObject["AddressOnParent"] = driveNumber.Value.ToString();

            if (!string.IsNullOrWhiteSpace(hostResourcePath))
                drive.LateBoundObject["HostResource"] = new[] { hostResourcePath };

            var newDriveResource = new[] { drive.LateBoundObject.GetText(TextFormat.CimDtd20) };

            var result = managementService.AddResourceSettings(machine.Path, newDriveResource, out var job, out var resultResources);

            return await CompleteJob(result, job, jobProgress, cancellationToken);
        }

        public static async Task<uint> InsertMedia(ManagementScope scope, string machineName, string controllerType, int controllerNumber, int deviceNumber, string storageType, string imagePath, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var machine = HyperVSupportRoutines.GetTargetComputer(scope, machineName) ??
                throw new Exception("Virtual machine not found.");

            return await InsertMedia(machine, controllerType, controllerNumber, deviceNumber, storageType, imagePath, jobProgress, cancellationToken);
        }

        public static async Task<uint> InsertMedia(this ComputerSystem machine, string controllerType, int controllerNumber, int deviceNumber, string storageType, string imagePath, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var controller = machine.GetController(controllerType, controllerNumber) ??
                throw new Exception($"Controller of type '{controllerType}' not found.");

            using var device = controller.GetControllerChild(deviceNumber);
            using var media = HyperVSupportRoutines.GetStorageTemplate(machine.Scope, storageType);
            using var managementService = HyperVSupportRoutines.GetVirtualSystemManagementService(machine.Scope);

            if (device == null || media == null || managementService == null)
                throw new Exception("Device or controller management not accessible.");

            media.LateBoundObject["Parent"] = device.Path.Path;

            if (!string.IsNullOrWhiteSpace(imagePath))
                media.LateBoundObject["HostResource"] = new[] { imagePath };

            var newDriveResource = new[] { media.LateBoundObject.GetText(TextFormat.CimDtd20) };

            var result = managementService.AddResourceSettings(machine.Path, newDriveResource, out var job, out var resultResources);

            return await CompleteJob(result, job, jobProgress, cancellationToken);
        }

        public static async Task<uint> InsertMedia(this ComputerSystem machine, ResourceAllocationSettingData device, string storageType, string imagePath, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            using var media = HyperVSupportRoutines.GetStorageTemplate(machine.Scope, storageType);
            using var managementService = HyperVSupportRoutines.GetVirtualSystemManagementService(machine.Scope);

            if (device == null || media == null || managementService == null)
                throw new Exception("Device or controller management not accessible.");

            media.LateBoundObject["Parent"] = device.Path.Path;

            if (!string.IsNullOrWhiteSpace(imagePath))
                media.LateBoundObject["HostResource"] = new[] { imagePath };

            var newDriveResource = new[] { media.LateBoundObject.GetText(TextFormat.CimDtd20) };

            var result = managementService.AddResourceSettings(machine.Path, newDriveResource, out var job, out var resultResources);

            return await CompleteJob(result, job, jobProgress, cancellationToken);
        }

        public static async Task<uint> EjectMedia(this ResourceAllocationSettingData device, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            var where = $"parent Like '%instanceId=\"{device.InstanceID.Replace(@"\", @"\\\\")}\"%'";

            using var resource = StorageAllocationSettingData.GetInstances(device.Scope, where).OfType<StorageAllocationSettingData>().FirstOrDefault();

            if (resource == null)
            {
                return 0;
            }

            using var managementService = HyperVSupportRoutines.GetVirtualSystemManagementService(device.Scope);

            var result = managementService.RemoveResourceSettings(new[] { resource.Path }, out var job);

            return await CompleteJob(result, job, jobProgress, cancellationToken);
        }

        public static async Task<uint> ConvertVirtualHardDisk(
            ManagementScope scope,
            string sourcePath,
            string destinationPath,
            VirtualHardDiskSettingData.TypeValues diskType,
            VirtualHardDiskSettingData.FormatValues diskFormat,
            Func<ConcreteJob, CancellationToken, Task> jobProgress,
            CancellationToken cancellationToken)
        {
            using var imageService = ImageManagementService.GetInstances(scope, default(string))
                .OfType<ImageManagementService>().FirstOrDefault();

            var path = new ManagementPath
            {
                Server = null,
                NamespacePath = imageService.Path.Path,
                ClassName = "Msvm_VirtualHardDiskSettingData"
            };

            using var settingsInstance = VirtualHardDiskSettingData.CreateInstance();
            settingsInstance.Path = new ManagementPath(destinationPath);
            settingsInstance.Type = diskType;
            settingsInstance.Format = diskFormat;
            settingsInstance.ParentPath = null;
            settingsInstance.MaxInternalSize = 0;
            settingsInstance.BlockSize = 0;
            settingsInstance.LogicalSectorSize = 0;
            settingsInstance.PhysicalSectorSize = 0;

            var result = imageService.ConvertVirtualHardDisk(sourcePath, settingsInstance.LateBoundObject.GetText(TextFormat.WmiDtd20), out var job);

            return await CompleteJob(result, job, jobProgress, cancellationToken);
        }

        public static async Task<uint> CompleteJob(uint result, ManagementPath jobPath, Func<ConcreteJob, CancellationToken, Task> progressCallback, CancellationToken cancellationToken)
        {
            if (jobPath == null || (ReturnCode)result != ReturnCode.Started)
            {
                return result;
            }

            using var job = new ConcreteJob(jobPath);

            // Get storage job information.
            job.LateBoundObject.Refresh();

            while ((JobState)job.JobState == JobState.Starting
                || (JobState)job.JobState == JobState.Running)
            {
                if (progressCallback == null)
                    await Task.Delay(500, cancellationToken);
                else
                    await progressCallback(job, cancellationToken);

                job.LateBoundObject.Refresh();
            }

            if (progressCallback != null)
            {
                await progressCallback(job, cancellationToken);
            }

            if ((JobState)job.JobState != JobState.Completed)
            {
                throw new JobFailedException(job);
            }

            return (uint)ReturnCode.Completed;
        }

    }
}