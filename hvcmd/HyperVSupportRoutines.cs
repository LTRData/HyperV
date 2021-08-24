// auth: Sergei Meleshchuk, June 2008.
// Based in part on powershell code by James O'Naill
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Threading;
using System.Xml;

namespace LTR.HyperV
{
    using Management.ROOT.virtualization.v2;

    public class JobFailedException : Exception
    {
        private static string FormatMessage(ManagementObject Job) =>
            $"Error {Job["ErrorCode"]}:{Environment.NewLine}{Environment.NewLine}{Job["ErrorDescription"]}";

        private static string FormatMessage(ConcreteJob Job)
        {
            var errmsg = Job.ErrorDescription;

            if (errmsg == null)
            {
                HyperVSupportRoutines.Messages.TryGetValue(Job.ErrorCode, out errmsg);
            }

            return $"Error {Job.ErrorCode}:{Environment.NewLine}{Environment.NewLine}{errmsg}";
        }

        public readonly ushort ErrorCode;

        public JobFailedException(ManagementObject Job)
            : base(FormatMessage(Job))
        {
            ErrorCode = (ushort)Job["ErrorCode"];
        }

        public JobFailedException(ConcreteJob Job)
            : base(FormatMessage(Job))
        {
            ErrorCode = Job.ErrorCode;
        }

        public JobFailedException(ManagementObject Job, Exception innerException)
            : base(FormatMessage(Job), innerException)
        {
            ErrorCode = (ushort)Job["ErrorCode"];
        }

        public JobFailedException(ConcreteJob Job, Exception innerException)
            : base(FormatMessage(Job), innerException)
        {
            ErrorCode = Job.ErrorCode;
        }

    }

    public static class HyperVSupportRoutines
    {
        public static ManagementScope GetManagementScope(string remoteMachine) =>
            new(@$"{remoteMachine}\root\virtualization\v2");

        public static void SetPropertyValueIfExists<T>(this ManagementBaseObject obj, string propertyName, T value)
        {
            var prop = obj.Properties.OfType<PropertyData>().FirstOrDefault(pd => pd.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));

            if (prop != null)
            {
                prop.Value = value;
            }
        }

        public static string EscapeManagementQueryString(string query)
        {
            return query
                .Replace(@"\", @"\\")
                .Replace(@"'", @"\'")
                .Replace("\"", "\\\"");
        }

        public static ComputerSystem GetTargetComputer(ManagementScope scope, string vmElementName) =>
            ComputerSystem.GetInstances(scope, $"ElementName = '{vmElementName}'").OfType<ComputerSystem>().FirstOrDefault();

        public static IEnumerable<ComputerSystem> GetTargetComputers(ManagementScope scope) =>
            ComputerSystem.GetInstances(scope, default(string)).OfType<ComputerSystem>();

        public static IEnumerable<ComputerSystem> GetVM(ManagementScope scope, string vmElementName) =>
            ComputerSystem.GetInstances(scope, $"ElementName = '{vmElementName}'").OfType<ComputerSystem>();

        public static ComputerSystem GetVM(ManagementScope scope, Guid id) =>
            ComputerSystem.GetInstances(scope, $"Name = '{id}'").OfType<ComputerSystem>().FirstOrDefault();

        public static ManagementObject[] FindObjectByPropertyValue(this IEnumerable<ManagementObject> sequence, string keyword) =>
            sequence.
                OfType<ManagementObject>().
                Where(o => o.Properties.OfType<PropertyData>().Any(v => v.Value != null && v.Value.ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)).
                ToArray();

        public static VMGeneration GetVMGeneration(ManagementScope scope, string machine)
        {
            using var vm = GetVM(scope, machine).FirstOrDefault() ??
                throw new Exception("Virtual machine not found.");

            return vm.GetVMGeneration();
        }

        public static VMGeneration GetVMGeneration(this ComputerSystem machine)
        {
            using var vm_settings = machine.GetVMSystemSettingsData();

            return vm_settings.GetVMGeneration();
        }

        public static VMGeneration GetVMGeneration(this VirtualSystemSettingData vm_settings)
        {
            var typestr = vm_settings.VirtualSystemSubType;

            if (typestr != null &&
                typestr.StartsWith("Microsoft:Hyper-V:SubType:", StringComparison.OrdinalIgnoreCase))
            {
                return (VMGeneration)int.Parse(typestr.Substring("Microsoft:Hyper-V:SubType:".Length), NumberFormatInfo.InvariantInfo);
            }

            return VMGeneration.G1;
        }

        public static ResourceAllocationSettingData GetController(this ComputerSystem machine, string resourceSubtype, int controllerNumber)
        {
            var vmName = machine.Name;

            var where = $"resourceSubtype='{resourceSubtype}' and instanceId Like 'Microsoft:{vmName}%' and (Address = {controllerNumber} or Address is null)";

            return ResourceAllocationSettingData.GetInstances(machine.Scope, where).OfType<ResourceAllocationSettingData>().FirstOrDefault();
        }

        public static ResourceAllocationSettingData GetFloppyController(this ComputerSystem machine) =>
            machine.GetController(ResourceSubType.ControllerFD, 0);

        public static ResourceAllocationSettingData GetIDEController(this ComputerSystem machine, int controllerNumber) =>
            machine.GetController(ResourceSubType.ControllerIDE, controllerNumber);

        public static ResourceAllocationSettingData GetSCSIController(this ComputerSystem machine, int controllerNumber) =>
            machine.GetController(ResourceSubType.ControllerSCSI, controllerNumber);

        public static SerialPortSettingData[] GetSerialPorts(this ComputerSystem machine)
        {
            var vmName = machine.Name;

            var where = $"resourceSubtype='{ResourceSubType.SerialPort}' and instanceId Like 'Microsoft:{vmName}%'";

            return SerialPortSettingData.GetInstances(machine.Scope, where).OfType<SerialPortSettingData>().ToArray();
        }

        public static RdvComponentSettingData GetRdvComponentSettings(this VirtualSystemSettingData vmSettings)
        {
            var wmiObjQuery = new RelatedObjectQuery(vmSettings.Path.Path, RdvComponentSettingData.CreatedClassName);
            using var wmiObjectSearch = new ManagementObjectSearcher(vmSettings.Scope, wmiObjQuery);
            var wmiObjCollection = new RdvComponentSettingData.RdvComponentSettingDataCollection(wmiObjectSearch.Get());

            return wmiObjCollection.OfType<RdvComponentSettingData>().FirstOrDefault();
        }

        public static TimeSyncComponentSettingData GetTimeSyncComponentSettingData(this VirtualSystemSettingData vmSettings)
        {
            var wmiObjQuery = new RelatedObjectQuery(vmSettings.Path.Path, TimeSyncComponentSettingData.CreatedClassName);
            using var wmiObjectSearch = new ManagementObjectSearcher(vmSettings.Scope, wmiObjQuery);
            var wmiObjCollection = new TimeSyncComponentSettingData.TimeSyncComponentSettingDataCollection(wmiObjectSearch.Get());

            return wmiObjCollection.OfType<TimeSyncComponentSettingData>().FirstOrDefault();
        }

        public static GuestServiceInterfaceComponentSettingData GetGuestServiceInterfaceComponentSettings(this VirtualSystemSettingData vmSettings)
        {
            var wmiObjQuery = new RelatedObjectQuery(vmSettings.Path.Path, GuestServiceInterfaceComponentSettingData.CreatedClassName);
            using var wmiObjectSearch = new ManagementObjectSearcher(vmSettings.Scope, wmiObjQuery);
            var wmiObjCollection = new GuestServiceInterfaceComponentSettingData.GuestServiceInterfaceComponentSettingDataCollection(wmiObjectSearch.Get());

            return wmiObjCollection.OfType<GuestServiceInterfaceComponentSettingData>().FirstOrDefault();
        }

        public static DiskDrive GetHostDiskDrive(ManagementScope scope, int hostDriveNumber) =>
            DiskDrive.GetInstances(scope, $"DriveNumber = {hostDriveNumber}").OfType<DiskDrive>().FirstOrDefault();

        public static VirtualSystemSettingData GetVMSystemSettingsData(this ComputerSystem machine)
        {
            var wmiObjQuery = new RelatedObjectQuery(machine.Path.Path, VirtualSystemSettingData.CreatedClassName);
            using var wmiObjectSearch = new ManagementObjectSearcher(machine.Scope, wmiObjQuery);

            // Ignore snapshots, backup progress etc
            var wmiObjCollection = new VirtualSystemSettingData.VirtualSystemSettingDataCollection(wmiObjectSearch.Get())
                .OfType<VirtualSystemSettingData>()
                .Where(wmiObj =>
                    wmiObj.VirtualSystemType == "Microsoft:Hyper-V:System:Realized" ||
                    wmiObj.VirtualSystemType == "Microsoft:Hyper-V:System:Planned");

            return wmiObjCollection.FirstOrDefault();
        }

        public static void ListControllers(this ComputerSystem machine)
        {
            var vmName = machine.Name;

            var where = string.Format(
                CultureInfo.InvariantCulture,
                "instanceId Like 'Microsoft:{0}%' and parent is null",
                vmName);

            var moControllerRasds = GetWmiObjects(machine.Scope, "MsVM_ResourceAllocationSettingData", where);

            foreach (var controller in moControllerRasds)
            {
                ListObjectProperties(controller);

                Console.WriteLine();
            }

        }

        public static void ListControllerChildren(this ComputerSystem machine, string controllerPath, string className)
        {
            var vmName = machine.Name;

            var where = $"resourceSubtype='{controllerPath}' and instanceId Like 'Microsoft:{vmName}%'";

            className ??= Constants.RASD_CLASS;
            
            var moControllerRasds = GetWmiObjects(machine.Scope, className, where);

            foreach (var controller in moControllerRasds)
            {

                var path = controller["instanceId"] as string;

                where = $"parent Like '%instanceId=\"{path.Replace(@"\", @"\\\\")}\"%'";

                var childrenDisks = GetWmiObjects(machine.Scope, className, where);

                foreach (var obj in childrenDisks)
                {
                    ListObjectProperties(obj);

                    Console.WriteLine();
                }

            }
        }

        public static void ListObjectProperties(this ManagementBaseObject obj)
        {
            Console.WriteLine(obj.ClassPath);

            foreach (var prop in obj.Properties)
            {
                if (prop.Value is string[] str_array)
                {
                    var str = string.Join(", ", str_array);
                    Console.WriteLine($"{prop.Name}: {str}");
                }
                else if (prop.Value is Array array)
                {
                    var str = string.Join(", ", array.Cast<object>());
                    Console.WriteLine($"{prop.Name}: {str}");
                }
                else
                {
                    Console.WriteLine($"{prop.Name}: {prop.Value ?? "(null)"}");
                }
            }
        }

        public static ResourceAllocationSettingData GetControllerChild(this ResourceAllocationSettingData controller, int deviceNumber)
        {

            var where = $"parent Like '%instanceId=\"{controller.InstanceID.Replace(@"\", @"\\\\")}\"%' and AddressOnParent = {deviceNumber}";

            var childrenDisks = ResourceAllocationSettingData.GetInstances(controller.Scope, where).OfType<ResourceAllocationSettingData>();

            return childrenDisks.FirstOrDefault();

        }

        public static VirtualSystemManagementService GetVirtualSystemManagementService(ManagementScope scope) =>
            VirtualSystemManagementService.GetInstances(scope, default(string))
                .OfType<VirtualSystemManagementService>().SingleOrDefault() ??
                    throw new Exception($"Cannot access VirtualSystemManagementService object");

        public static VirtualEthernetSwitchManagementService GetVirtualSwitchManagementService(ManagementScope scope) =>
            VirtualEthernetSwitchManagementService.GetInstances(scope, default(string))
                .OfType<VirtualEthernetSwitchManagementService>().SingleOrDefault() ??
                    throw new Exception($"Cannot access VirtualEthernetSwitchManagementService object");

        public static StorageAllocationSettingData GetISOTemplate(ManagementScope scope) =>
            GetStorageTemplate(scope, ResourceSubType.StorageVirtualDVD);

        public static StorageAllocationSettingData GetVHDTemplate(ManagementScope scope) =>
            GetStorageTemplate(scope, ResourceSubType.StorageVirtualDisk);

        public static StorageAllocationSettingData GetPHDTemplate(ManagementScope scope) =>
            GetStorageTemplate(scope, ResourceSubType.StoragePhysicalDisk);

        public static StorageAllocationSettingData GetVFDTemplate(ManagementScope scope) =>
            GetStorageTemplate(scope, ResourceSubType.StorageVirtualFD);

        public static string GetVMDiskInstanceID(this ComputerSystem machine, string controllerType, int controllerNumber, int deviceNumber)
        {
            using var controller = machine.GetController(controllerType, controllerNumber) ??
                throw new Exception($"Controller of type '{controllerType}' not found.");

            using var device = GetControllerChild(controller, deviceNumber) ??
                throw new Exception("Device not found.");

            return device.InstanceID;
        }

        public static int GetControllerNextDeviceNumber(this ComputerSystem machine, string controllerType, int controllerNumber)
        {
            using var controller = machine.GetController(controllerType, controllerNumber) ??
                throw new Exception($"Controller of type '{controllerType}' not found.");

            var where = $"parent Like '%instanceId=\"{controller.InstanceID.Replace(@"\", @"\\\\")}\"%'";

            var children = ResourceAllocationSettingData.GetInstances(controller.Scope, where).OfType<ResourceAllocationSettingData>();

            return children.Max(child => new int?(int.Parse(child.AddressOnParent))).GetValueOrDefault(-1) + 1;
        }

        public static int GetControllerFreeDeviceNumber(this ResourceAllocationSettingData controller)
        {
            var where = $"parent Like '%instanceId=\"{controller.InstanceID.Replace(@"\", @"\\\\")}\"%'";

            var children = ResourceAllocationSettingData.GetInstances(controller.Scope, where).OfType<ResourceAllocationSettingData>();

            return children.Max(child => int.Parse(child.AddressOnParent)) + 1;
        }

        public static ManagementPath GetVMDiskManagementPath(this ComputerSystem machine, string controllerType, int controllerNumber, int deviceNumber)
        {
            using var controller = machine.GetController(controllerType, controllerNumber) ??
                throw new Exception($"Controller of type '{controllerType}' not found.");

            using var device = GetControllerChild(controller, deviceNumber) ??
                throw new Exception("Device not found.");

            return device.Path;
        }

        public static ResourceAllocationSettingData GetResourceTemplate(ManagementScope scope, string resourceSubType)
        {
            var defaultDriveQuery = $"ResourceSubType LIKE \"{resourceSubType}\" AND InstanceID LIKE \"%Default\"";
            var defaultDiskDriveSettingsObjs = ResourceAllocationSettingData.GetInstances(scope, defaultDriveQuery);

            if (defaultDiskDriveSettingsObjs.Count != 1)
            {
                throw new Exception($"Cannot find settings template for resource type '{resourceSubType}'");
            }

            var defaultDiskDriveSettings = defaultDiskDriveSettingsObjs.OfType<ResourceAllocationSettingData>().First();

            return new ResourceAllocationSettingData((ManagementBaseObject)defaultDiskDriveSettings.LateBoundObject.Clone());
        }

        public static StorageAllocationSettingData GetStorageTemplate(ManagementScope scope, string resourceSubType)
        {
            var defaultDriveQuery = $"ResourceSubType LIKE \"{resourceSubType}\" AND InstanceID LIKE \"%Default\"";
            var defaultDiskDriveSettingsObjs = StorageAllocationSettingData.GetInstances(scope, defaultDriveQuery);

            if (defaultDiskDriveSettingsObjs.Count != 1)
            {
                throw new Exception($"Cannot find settings template for storage type '{resourceSubType}'");
            }

            var defaultDiskDriveSettings = defaultDiskDriveSettingsObjs.OfType<StorageAllocationSettingData>().First();

            return new StorageAllocationSettingData((ManagementBaseObject)defaultDiskDriveSettings.LateBoundObject.Clone());
        }

#region generic wmi helpers

        internal static string FixPath(string path) =>
            path.
                Replace("\\", "\\\\").
                Replace("\"", "\\\"");

        public static ManagementObject GetWmiObject(ManagementScope scope, string classname, string where)
        {
            using var resultset = GetWmiObjects(scope, classname, where);

            return resultset.OfType<ManagementObject>().SingleOrDefault() ??
                throw new Exception($"Cannot find class '{classname} where {where}'");
        }

        private static ManagementObjectCollection GetWmiObjects(ManagementScope scope, string classname, string where)
        {
            string query;

            if (where != null)
            {
                query = $"select * from {classname} where {where}";
            }
            else
            {
                query = $"select * from {classname}";
            }

            using var searcher = new ManagementObjectSearcher(scope, new ObjectQuery(query));
            return searcher.Get();
        }

#endregion generic wmi helpers

        // -- end of main helpers

        public static ProcessorSettingData GetProcSettings(this VirtualSystemSettingData vmSettings)
        {
            var wmiObjQuery = new RelatedObjectQuery(vmSettings.Path.Path, ProcessorSettingData.CreatedClassName);
            using var wmiObjectSearch = new ManagementObjectSearcher(vmSettings.Scope, wmiObjQuery);
            var wmiObjCollection = new ProcessorSettingData.ProcessorSettingDataCollection(wmiObjectSearch.Get());

            return wmiObjCollection.OfType<ProcessorSettingData>().FirstOrDefault();
        }

        public static GuestCommunicationServiceSettingData GetGuestCommServiceSettings(this VirtualSystemSettingData vmSettings)
        {
            var wmiObjQuery = new RelatedObjectQuery(vmSettings.Path.Path, GuestCommunicationServiceSettingData.CreatedClassName);
            using var wmiObjectSearch = new ManagementObjectSearcher(vmSettings.Scope, wmiObjQuery);
            var wmiObjCollection = new GuestCommunicationServiceSettingData.GuestCommunicationServiceSettingDataCollection(wmiObjectSearch.Get());

            return wmiObjCollection.OfType<GuestCommunicationServiceSettingData>().FirstOrDefault();
        }

        public static MemorySettingData GetMemSettings(this VirtualSystemSettingData vmSettings)
        {
            var wmiObjQuery = new RelatedObjectQuery(vmSettings.Path.Path, MemorySettingData.CreatedClassName);
            using var wmiObjectSearch = new ManagementObjectSearcher(vmSettings.Scope, wmiObjQuery);
            var wmiObjCollection = new MemorySettingData.MemorySettingDataCollection(wmiObjectSearch.Get());

            return wmiObjCollection.OfType<MemorySettingData>().FirstOrDefault();
        }

        public static ShutdownComponent GetShutdownComponent(ManagementScope scope, string machineGuid) =>
            ShutdownComponent.GetInstances(scope, $"SystemName='{machineGuid}'")
                .OfType<ShutdownComponent>().FirstOrDefault();

        public static ShutdownComponent GetShutdownComponent(this ComputerSystem machine) =>
            GetShutdownComponent(machine.Scope, machine.Name);

        public static uint CompleteJob_old(ManagementScope scope, ManagementBaseObject outParams, Action<ManagementObject> progressCallback)
        {
            var result = (ReturnCode)outParams["ReturnValue"];
            if (result != ReturnCode.Started)
                return (uint)result;

            // Retrieve the storage job path. This is a full wmi path.
            string JobPath = outParams["Job"] as string;
            
            using var Job = new ManagementObject(scope, new ManagementPath(JobPath), null);
            
            // Get storage job information.
            Job.Get();
            while ((JobState)Job["JobState"] == JobState.Starting
                || (JobState)Job["JobState"] == JobState.Running)
            {
                if (progressCallback == null)
                    Thread.Sleep(1000);
                else
                    progressCallback(Job);

                Job.Get();
            }

            progressCallback?.Invoke(Job);

            var jobState = (JobState)Job["JobState"];

            if (jobState == JobState.Completed)
                return 0;

            throw new JobFailedException(Job);
        }

        public static EthernetPortAllocationSettingData CreateInternalEthernetPort(ManagementScope scope, string name)
        {
            using var hostComputerSystem = HyperVSupportRoutines.GetTargetComputer(scope, Environment.MachineName);
            using var default_settings = EthernetPortAllocationSettingData.GetInstances(scope, "InstanceID LIKE \"%Default\"").OfType<EthernetPortAllocationSettingData>().First();

            var settings = new EthernetPortAllocationSettingData((ManagementBaseObject)default_settings.LateBoundObject.Clone());
            settings.LateBoundObject["ElementName"] = name;
            settings.LateBoundObject["HostResource"] = new[] { hostComputerSystem.Path.Path };
            return settings;
        }

        public static EthernetPortAllocationSettingData CreateExternalEthernetPort(ManagementScope scope, string name, string adapter_name)
        {
            using var adapter = ExternalEthernetPort.GetInstances(scope, $"Name=\"{adapter_name}\"").OfType<ExternalEthernetPort>().Single();
            using var default_settings = EthernetPortAllocationSettingData.GetInstances(scope, "InstanceID LIKE \"%Default\"").OfType<EthernetPortAllocationSettingData>().First();

            var settings = new EthernetPortAllocationSettingData((ManagementBaseObject)default_settings.LateBoundObject.Clone());
            settings.LateBoundObject["ElementName"] = name;
            settings.LateBoundObject["HostResource"] = new[] { adapter.Path.Path };
            return settings;
        }

        public static VirtualEthernetSwitch GetEthernetSwitchByName(ManagementScope scope, string name) =>
            VirtualEthernetSwitch.GetInstances(scope, $"ElementName = \"{name}\"").OfType<VirtualEthernetSwitch>().FirstOrDefault();

        public static VirtualEthernetSwitch GetEthernetSwitchById(ManagementScope scope, string id) =>
            VirtualEthernetSwitch.GetInstances(scope, $"Name = \"{id}\"").OfType<VirtualEthernetSwitch>().FirstOrDefault();

        public static VirtualEthernetSwitch[] GetEthernetSwitches(ManagementScope scope) =>
            VirtualEthernetSwitch.GetInstances(scope, string.Empty).OfType<VirtualEthernetSwitch>().ToArray();

        public static EthernetSwitchPort[] GetEthernetSwitchPorts(this VirtualEthernetSwitch sw) =>
            (sw.LateBoundObject as ManagementObject)
                .GetRelated("Msvm_EthernetSwitchPort",
                            "Msvm_SystemDevice",
                            null, null, null, null, false, null)
                .OfType<ManagementBaseObject>()
                .Select(mbo => new EthernetSwitchPort(mbo))
                .ToArray();

        public static EthernetPortAllocationSettingData GetEthernetSwitchPortSettingsData(this EthernetSwitchPort port) =>
            (port.LateBoundObject as ManagementObject)
                .GetRelated("Msvm_EthernetPortAllocationSettingData",
                            "Msvm_ElementSettingData",
                            null, null, null, null, false, null)
                .OfType<ManagementBaseObject>()
                .Select(mbo => new EthernetPortAllocationSettingData(mbo))
                .Single();

        public static ManagementObject[] GetEthernetSwitchPortSettingsDataHostResources(this EthernetPortAllocationSettingData settingsdata)
        {
            if (settingsdata.HostResource == null)
            {
                return null;
            }

            var mo = Array.ConvertAll(settingsdata.HostResource, hr => new ManagementObject(hr));

            return mo;
        }

        public static ExternalEthernetPort[] GetEthernetSwitchExternalPorts(this EthernetPortAllocationSettingData settingsdata) =>
            settingsdata.GetEthernetSwitchPortSettingsDataHostResources()
                .Where(mo => mo.ClassPath.ClassName.Equals(ExternalEthernetPort.CreatedClassName, StringComparison.OrdinalIgnoreCase))
                .Select(mo => new ExternalEthernetPort(mo))
                .ToArray();

        public static ComputerSystem[] GetEthernetSwitchInternalPorts(this EthernetPortAllocationSettingData settingsdata) =>
            settingsdata.GetEthernetSwitchPortSettingsDataHostResources()
                .Where(mo => mo.ClassPath.ClassName.Equals(ComputerSystem.CreatedClassName, StringComparison.OrdinalIgnoreCase))
                .Select(mo => new ComputerSystem(mo))
                .ToArray();

        public static string DefaultSwitchId { get; } = "C08CB7B8-9B3C-408E-8E30-5E16A3AEB444";

        public static Guid DefaultSwitchGuid { get; } = new Guid(DefaultSwitchId);

        public static VirtualEthernetSwitch GetEthernetDefaultSwitch(ManagementScope scope) =>
            GetEthernetSwitchById(scope, DefaultSwitchId);

        /// <summary>
        /// Common utility function to get a service object
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static ManagementObject GetServiceObject(ManagementScope scope, string serviceName)
        {
            scope.Connect();
            var wmiPath = new ManagementPath(serviceName);
            using var serviceClass = new ManagementClass(scope, wmiPath, null);
            var services = serviceClass.GetInstances();

            var serviceObject = services.OfType<ManagementObject>().FirstOrDefault();

            return serviceObject;
        }

        public static ManagementObject GetHostSystemDevice(string deviceClassName, string deviceObjectElementName, ManagementScope scope) =>
            GetSystemDevice(deviceClassName, deviceObjectElementName, Environment.MachineName, scope);

        public static ManagementObject GetSystemDevice
        (
            string deviceClassName,
            string deviceObjectElementName,
            string vmName,
            ManagementScope scope)
        {
            using var computerSystem = HyperVSupportRoutines.GetTargetComputer(scope, vmName);

            var systemDevices = ((ManagementObject)computerSystem.LateBoundObject).GetRelated
            (
                deviceClassName,
                "Msvm_SystemDevice",
                null,
                null,
                "PartComponent",
                "GroupComponent",
                false,
                null
            );

            var systemDevice = systemDevices
                .OfType<ManagementObject>()
                .FirstOrDefault(device => device["ElementName"].ToString().Equals(deviceObjectElementName, StringComparison.OrdinalIgnoreCase));

            return systemDevice;
        }

        public static bool JobCompleted(ManagementBaseObject outParams, ManagementScope scope)
        {
            var jobCompleted = true;

            // Retrieve the storage job path. This is a full WMI path.
            var JobPath = (string)outParams["Job"];

            using var Job = new ManagementObject(scope, new ManagementPath(JobPath), null);

            // Get storage job information.
            Job.Get();
            while ((JobState)Job["JobState"] == JobState.Starting
                || (JobState)Job["JobState"] == JobState.Running)
            {
                Console.WriteLine("In progress... {0}% completed.", Job["PercentComplete"]);
                Thread.Sleep(1000);
                Job.Get();
            }

            JobState jobState = (JobState)Job["JobState"];
            if (jobState != JobState.Completed)
            {
                // The job failed, so print the error code and description.
                UInt16 jobErrorCode = (UInt16)Job["ErrorCode"];
                Console.WriteLine("Error Code:{0}", jobErrorCode);
                Console.WriteLine("ErrorDescription: {0}", (string)Job["ErrorDescription"]);

                jobCompleted = false;
            }

            return jobCompleted;
        }

        public static ManagementObject GetVirtualSystemSettingData(ManagementObject vm)
        {
            using var vmSettings = vm.GetRelated(
                "Msvm_VirtualSystemSettingData",
                "Msvm_SettingsDefineState",
                null,
                null,
                "SettingData",
                "ManagedElement",
                false,
                null);

            return vmSettings.OfType<ManagementObject>().SingleOrDefault() ??
                throw new Exception($"Cannot find settings for virtual machine {vm.GetPropertyValue("Name")}");
        }


        enum ValueRole
        {
            Default = 0,
            Minimum = 1,
            Maximum = 2,
            Increment = 3
        }
        enum ValueRange
        {
            Default = 0,
            Minimum = 1,
            Maximum = 2,
            Increment = 3
        }


        //
        // Get RASD definitions
        //
        public static ManagementObject GetResourceAllocationsettingDataDefault
        (
            ManagementScope scope,
            UInt16 resourceType,
            string resourceSubType,
            string otherResourceType
            )
        {
            ManagementObject RASD = null;

            string query;

            if (resourceType == ResourceType.Other)
            {
                query = $"select * from Msvm_ResourcePool where ResourceType = '{resourceType}' and ResourceSubType = null and OtherResourceType = {otherResourceType}";
            }
            else
            {
                query = $"select * from Msvm_ResourcePool where ResourceType = '{resourceType}' and ResourceSubType ='{resourceSubType}' and OtherResourceType = null";
            }

            using var searcher = new ManagementObjectSearcher(scope, new ObjectQuery(query));

            ManagementObjectCollection poolResources = searcher.Get();

            //Get pool resource allocation ability
            if (poolResources.Count == 1)
            {
                foreach (ManagementObject poolResource in poolResources)
                {
                    ManagementObjectCollection allocationCapabilities = poolResource.GetRelated("Msvm_AllocationCapabilities");
                    foreach (ManagementObject allocationCapability in allocationCapabilities)
                    {
                        ManagementObjectCollection settingDatas = allocationCapability.GetRelationships("Msvm_SettingsDefineCapabilities");
                        foreach (ManagementObject settingData in settingDatas)
                        {

                            if (Convert.ToInt16(settingData["ValueRole"]) == (UInt16)ValueRole.Default)
                            {
                                RASD = new ManagementObject(settingData["PartComponent"].ToString());
                                break;
                            }
                        }
                    }
                }
            }

            return RASD;
        }


        public static ManagementObject GetResourceAllocationsettingData(
            ManagementObject vm,
            UInt16 resourceType,
            string resourceSubType,
            string otherResourceType)
        {
            ManagementObject RASD = null;
            using var settingDatas = vm.GetRelated("Msvm_VirtualSystemsettingData");

            foreach (ManagementObject settingData in settingDatas)
            {
                using (settingData)
                {
                    //retrieve the RASD
                    using ManagementObjectCollection RASDs = settingData.GetRelated("Msvm_ResourceAllocationsettingData");

                    foreach (ManagementObject rasdInstance in RASDs)
                    {
                        if (Convert.ToUInt16(rasdInstance["ResourceType"]) == resourceType)
                        {
                            //found the matching type
                            if (resourceType == ResourceType.Other)
                            {
                                if (rasdInstance["OtherResourceType"].ToString() == otherResourceType)
                                {
                                    RASD = rasdInstance;
                                    break;
                                }
                            }
                            else
                            {
                                if (rasdInstance["ResourceSubType"].ToString() == resourceSubType)
                                {
                                    RASD = rasdInstance;
                                    break;
                                }
                            }
                        }
                    }

                }
            }
            return RASD;
        }

        public static void PrintEmbeddedInstance(string embeddedInstance)
        {
            var doc = new XmlDocument();
            doc.LoadXml(embeddedInstance);

            var nodelist = doc.SelectNodes(@"/INSTANCE/@CLASSNAME");
            if (nodelist.Count != 1)
            {
                throw new FormatException();
            }
            Console.WriteLine($"Contents of class {nodelist[0].Value}:");

            nodelist = doc.SelectNodes("//PROPERTY");
            foreach (XmlNode node in nodelist)
            {
                Console.WriteLine($"Property : {node.Attributes["NAME"].Value}");
                Console.WriteLine($"\tType: {node.Attributes["TYPE"].Value}");

                var valueNode = node.SelectSingleNode("VALUE");
                Console.WriteLine($"\tValue: {valueNode.InnerText}");
            }
        }

        public static readonly Dictionary<uint, string> Messages = new()
        {
            {
                0u,
                "Completed successfully."
            },
            {
                4096u,
                "Method parameters checked - Job Started."
            },
            {
                32768u,
                "Failed."
            },
            {
                32769u,
                "Access denied."
            },
            {
                32770u,
                "Not supported."
            },
            {
                32771u,
                "Unknown status."
            },
            {
                32772u,
                "Timeout."
            },
            {
                32773u,
                "Invalid parameter."
            },
            {
                32774u,
                "System is in use."
            },
            {
                32775u,
                "Invalid state for operation."
            },
            {
                32776u,
                "Incorrect data type."
            },
            {
                32777u,
                "System not available."
            },
            {
                32778u,
                "Out of memory."
            },
            {
                32779u,
                "File not found."
            },
            {
                32780u,
                "System not ready."
            },
            {
                32781u,
                "Machine is locked and cannot be shut down without force option."
            },
            {
                32782u,
                "A system shutdown is in progress."
            }
        };

    }


    public enum VirtualHardDiskType
    {
        Fixed = 2,
        Dynamic = 3,
        Differencing = 4
    }

    public enum VirtualHardDiskFormat
    {
        Unknown = 0,
        Vhd = 2,
        Vhdx = 3
    }

    internal static class Constants
    {
        internal const string DefineVirtualSystem = "DefineVirtualSystem";

        internal const string ModifyVirtualSystem = "ModifyVirtualSystem";

        internal const uint ERROR_SUCCESS = 0;

        internal const uint ERROR_INV_ARGUMENTS = 87;

        internal const string RASD_CLASS = "MsVM_ResourceAllocationSettingData";
    }

}

