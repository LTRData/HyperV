using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace LTR.HyperV
{
    using Management.ROOT.virtualization.v2;
    using System.IO;
    using System.Threading;

    public static class HyperVCommands
    {
        public async static Task<uint> cmdAddVNIC(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            using var machine = HyperVSupportRoutines.GetTargetComputer(args[0], scope) ??
                throw new Exception("Virtual machine not found.");

            await HyperVTasks.CreateNICforVM(machine, jobProgress, cancellationToken);

            return 0;
        }

        public async static Task<uint> cmdAddENIC(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            using var machine = HyperVSupportRoutines.GetTargetComputer(args[0], scope) ??
                throw new Exception("Virtual machine not found.");

            await HyperVTasks.CreateEmulatedNICforVM(machine, jobProgress, cancellationToken);

            return 0;
        }

        public async static Task<uint> cmdAddSwitch(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual switch name.");

            var switch_name = args[0];

            var ports = new[] { HyperVSupportRoutines.CreateInternalEthernetPort(scope, $"{switch_name}_InternalPort") };

            await HyperVTasks.CreateEthernetSwitch(scope, switch_name, ports, jobProgress, cancellationToken);

            return 0;
        }

        public static Task<uint> cmdListSwitches(ManagementScope scope, List<string> _1, Func<ConcreteJob, CancellationToken, Task> _2, CancellationToken _3)
        {
            var sws = HyperVSupportRoutines.GetEthernetSwitches(scope);

            foreach (var sw in sws)
            {
                HyperVSupportRoutines.ListObjectProperties(sw.LateBoundObject);

                foreach (var port in sw.GetEthernetSwitchPorts())
                {
                    HyperVSupportRoutines.ListObjectProperties(port.LateBoundObject);

                    using var settingsdata = port.GetEthernetSwitchPortSettingsData();

                    HyperVSupportRoutines.ListObjectProperties(settingsdata.LateBoundObject);

                    foreach (var adapter in settingsdata.GetEthernetSwitchExternalPorts())
                    {
                        Console.WriteLine("This switch is connected to the following external adapter:");
                        HyperVSupportRoutines.ListObjectProperties(adapter.LateBoundObject);
                    }

                    foreach (var connection in settingsdata.GetEthernetSwitchInternalPorts())
                    {
                        Console.WriteLine("This switch is connected to the following internal connection:");
                        HyperVSupportRoutines.ListObjectProperties(connection.LateBoundObject);
                    }
                }

                Console.WriteLine();
            }

            return Task.FromResult(0u);
        }

        public static Task<uint> cmdConvertVHD(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
            {
                throw new Exception("Missing source image file path.");
            }
            string sourcePath = args[0];
            args.RemoveAt(0);

            if (args.Count == 0)
            {
                throw new Exception("Missing target image file path.");
            }
            string targetPath = args[0];
            args.RemoveAt(0);

            if (args.Count == 0)
            {
                throw new Exception("Missing image dynamic/fixed type specification.");
            }
            string diskType = args[0];
            args.RemoveAt(0);

            if (args.Count == 0)
            {
                throw new Exception("Missing image vhd/vhdx format specification.");
            }
            string diskFormat = args[0];
            args.RemoveAt(0);

            var vdiskType = diskType.ToLowerInvariant() switch
            {
                "fixed" => VirtualHardDiskSettingData.TypeValues.Fixed,

                "dynamic" => VirtualHardDiskSettingData.TypeValues.Dynamic,

                _ => throw new Exception($"Virtual disk type {diskType} not supported."),
            };

            var vdiskFormat = diskFormat.ToLowerInvariant() switch
            {
                "vhd" => VirtualHardDiskSettingData.FormatValues.VHD,

                "vhdx" => VirtualHardDiskSettingData.FormatValues.VHDX,

                _ => throw new Exception($"Virtual disk format {diskFormat} not supported."),
            };

            return HyperVTasks.ConvertVirtualHardDisk(scope, sourcePath, targetPath, vdiskType, vdiskFormat, jobProgress, cancellationToken);
        }

        public static Task<uint> cmdList(ManagementScope scope, List<string> _)
        {
            foreach (var obj in HyperVSupportRoutines.GetTargetComputers(scope))
            {
                using (obj)
                {
                    Console.Write($"{obj.ElementName}: ");
                    var machinestate = (VirtualMachineState)obj.EnabledState;
                    Console.Write(machinestate.ToString().Replace('_', ' '));
                    var OnTimeInMilliseconds = obj.OnTimeInMilliseconds;
                    if (OnTimeInMilliseconds != 0)
                    {
                        Console.Write($" (Uptime {TimeSpan.FromMilliseconds(OnTimeInMilliseconds):g})");
                    }
                    Console.WriteLine();
                }
            }

            return Task.FromResult(0u);
        }

        public static Task<uint> cmdQuery(ManagementScope scope, List<string> args)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            using var machine = HyperVSupportRoutines.GetTargetComputer(args[0], scope) ??
                throw new Exception("Virtual machine not found.");

            HyperVSupportRoutines.ListObjectProperties(machine.LateBoundObject);

            return Task.FromResult(0u);
        }

        public static Task<uint> cmdChangeState(ManagementScope scope, List<string> args, VirtualMachineState newState, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            string machineName = args[0];
            args.RemoveAt(0);

            return HyperVTasks.ChangeState(scope, machineName, newState, jobProgress, cancellationToken);
        }

        public static Task<uint> cmdShutdown(ManagementScope scope, List<string> args)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            string machineName = args[0];
            args.RemoveAt(0);

            bool forceShutdown = false;
            if (args.Count > 0 && args[0].Equals("force", StringComparison.InvariantCultureIgnoreCase))
            {
                forceShutdown = true;
                args.RemoveAt(0);
            }

            return HyperVTasks.Shutdown(scope, machineName, forceShutdown);
        }

        public static Task<uint> cmdFD(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            string machineName = args[0];
            args.RemoveAt(0);

            string imagePath = null;
            if (args.Count > 0)
            {
                imagePath = args[0];
                args.RemoveAt(0);
            }

            return HyperVTasks.AddDriveWithMedia(scope, machineName, ResourceSubType.ControllerFD, 0, 0, ResourceSubType.StorageVirtualDisk, imagePath, jobProgress, cancellationToken);
        }

        public static Task<uint> cmdIDEPHD(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            string machineName = args[0];
            args.RemoveAt(0);

            int hostDriveNumber = 0;
            if (args.Count > 0)
            {
                hostDriveNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            int deviceNumber = 0;
            if (args.Count > 0)
            {
                deviceNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            int controllerNumber = 1;
            if (args.Count > 0)
            {
                controllerNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            return HyperVTasks.AddPhysicalDisk(scope, machineName, ResourceSubType.ControllerIDE, controllerNumber, null, hostDriveNumber, jobProgress, cancellationToken);
        }

        public static Task<uint> cmdSCSIPHD(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            string machineName = args[0];
            args.RemoveAt(0);

            int hostDriveNumber = 0;
            if (args.Count > 0)
            {
                hostDriveNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            int deviceNumber = 0;
            if (args.Count > 0)
            {
                deviceNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            int controllerNumber = 1;
            if (args.Count > 0)
            {
                controllerNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            return HyperVTasks.AddPhysicalDisk(scope, machineName, ResourceSubType.ControllerSCSI, controllerNumber, null, hostDriveNumber, jobProgress, cancellationToken);
        }

        public static Task<uint> cmdIDEDVD(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            string machineName = args[0];
            args.RemoveAt(0);

            string imagePath = null;
            if (args.Count > 0)
            {
                imagePath = args[0];
                args.RemoveAt(0);
            }

            int deviceNumber = 0;
            if (args.Count > 0)
            {
                deviceNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            int controllerNumber = 1;
            if (args.Count > 0)
            {
                controllerNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            return HyperVTasks.InsertMedia(scope, machineName, ResourceSubType.ControllerIDE, controllerNumber, deviceNumber, ResourceSubType.StorageVirtualDVD, imagePath, jobProgress, cancellationToken);
        }

        public static Task<uint> cmdSCSIDVD(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            string machineName = args[0];
            args.RemoveAt(0);

            string imagePath = null;
            if (args.Count > 0)
            {
                imagePath = args[0];
                args.RemoveAt(0);
            }

            int? deviceNumber = null;
            if (args.Count > 0)
            {
                deviceNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            int controllerNumber = 1;
            if (args.Count > 0)
            {
                controllerNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            return HyperVTasks.AddDriveWithMedia(scope, machineName, ResourceSubType.ControllerSCSI, controllerNumber, deviceNumber, ResourceSubType.DVDVirtual, imagePath, jobProgress, cancellationToken);
        }

        public static Task<uint> cmdIDEVHD(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            string machineName = args[0];
            args.RemoveAt(0);

            string imagePath = null;
            if (args.Count > 0)
            {
                imagePath = args[0];
                args.RemoveAt(0);
            }

            int deviceNumber = 0;
            if (args.Count > 0)
            {
                deviceNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            int controllerNumber = 1;
            if (args.Count > 0)
            {
                controllerNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            return HyperVTasks.InsertMedia(scope, machineName, ResourceSubType.ControllerIDE, controllerNumber, deviceNumber, ResourceSubType.StorageVirtualDisk, imagePath, jobProgress, cancellationToken);
        }

        public static Task<uint> cmdSCSIVHD(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            string machineName = args[0];
            args.RemoveAt(0);

            string imagePath = null;
            if (args.Count > 0)
            {
                imagePath = args[0];
                args.RemoveAt(0);
            }

            int deviceNumber = 0;
            if (args.Count > 0)
            {
                deviceNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            int controllerNumber = 0;
            if (args.Count > 0)
            {
                controllerNumber = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            return HyperVTasks.InsertMedia(scope, machineName, ResourceSubType.ControllerSCSI, controllerNumber, deviceNumber, ResourceSubType.StorageVirtualDisk, imagePath, jobProgress, cancellationToken);
        }


        public static Task<uint> cmdDestroyVM(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            var machineName = args[0];
            args.RemoveAt(0);

            return HyperVTasks.DestroyVM(scope, machineName, jobProgress, cancellationToken);
        }

        public static Task<uint> cmdCreateSCSI(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            var machineName = args[0];
            args.RemoveAt(0);

            return HyperVTasks.CreateSCSIforVM(scope, machineName, jobProgress, cancellationToken);
        }

        public static async Task<uint> cmdCreateVM(ManagementScope scope, List<string> args, Func<ConcreteJob, CancellationToken, Task> jobProgress, CancellationToken cancellationToken)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            var machineName = args[0];
            args.RemoveAt(0);

            if (args.Count == 0)
                throw new Exception("Missing disk image path or physical drive number.");

            var vhdpath = args[0];
            args.RemoveAt(0);

            if (args.Count == 0)
                throw new Exception("Missing memory limit.");

            long memory_mb = long.Parse(args[0]);
            args.RemoveAt(0);

            int vcpus = 2;
            if (args.Count > 0)
            {
                vcpus = int.Parse(args[0]);
                args.RemoveAt(0);
            }

            using var machine = await HyperVTasks.CreateVM(scope, machineName, VMGeneration.G1, null, memory_mb, vcpus, jobProgress, cancellationToken);

            Console.WriteLine($"Created virtual machine {machine.ElementName}.");

            using var synt_nic = await HyperVTasks.CreateNICforVM(machine, jobProgress, cancellationToken);

            Console.WriteLine($"Attached virtual network adapter with address {synt_nic.Address}.");

            using var emul_nic = await HyperVTasks.CreateEmulatedNICforVM(machine, jobProgress, cancellationToken);

            Console.WriteLine($"Attached emulated network adapter with address {emul_nic.Address}.");

            await HyperVTasks.AddDriveWithMedia(machine, ResourceSubType.ControllerIDE, 1, 0, ResourceSubType.DVDVirtual, null, jobProgress, cancellationToken);

            Console.WriteLine("Attached virtual IDE DVD-ROM drive.");

            if (int.TryParse(vhdpath, out var hostDriveNumber))
            {
                await HyperVTasks.AddPhysicalDisk(machine, ResourceSubType.ControllerIDE, 0, 0, hostDriveNumber, jobProgress, cancellationToken);

                Console.WriteLine($"Attached host physical disk {vhdpath} as primary IDE HD.");
            }
            else
            {
                vhdpath = Path.GetFullPath(vhdpath);
                await HyperVTasks.AddDriveWithMedia(machine, ResourceSubType.ControllerIDE, 0, 0, ResourceSubType.DiskVirtual, null, jobProgress, cancellationToken);

                Console.WriteLine("Created primary IDE HD.");

                await HyperVTasks.InsertMedia(machine, ResourceSubType.ControllerIDE, 0, 0, ResourceSubType.StorageVirtualDisk, vhdpath, jobProgress, cancellationToken);

                Console.WriteLine($"Attached virtual disk {vhdpath} as primary IDE HD.");
            }

            return 0u;
        }

        public static Task<uint> cmdLISTCTRL(ManagementScope scope, List<string> args)
        {
            if (args.Count == 0)
                throw new Exception("Missing virtual machine name.");

            var machineName = args[0];
            args.RemoveAt(0);

            string ctrl = null;
            if (args.Count > 0)
            {
                ctrl = args[0];
                args.RemoveAt(0);
            }

            string className = null;
            if (args.Count > 0)
            {
                className = args[0];
                args.RemoveAt(0);
            }

            using var machine = HyperVSupportRoutines.GetTargetComputer(machineName, scope) ??
                throw new Exception("Virtual machine not found.");

            if (ctrl == null)
            {
                HyperVSupportRoutines.ListControllers(machine);
            }
            else
            {
                HyperVSupportRoutines.ListControllerChildren(machine, ctrl, className);
            }

            return Task.FromResult(0u);
        }

    }
}
