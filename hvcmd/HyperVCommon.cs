using System;

namespace LTR.HyperV
{
    public enum VMGeneration
    {
        G1 = 1,
        G2 = 2
    }

    public static class ResourceType
    {
        public const UInt16 Other = 1;
        public const UInt16 ComputerSystem = 2;
        public const UInt16 Processor = 3;
        public const UInt16 Memory = 4;
        public const UInt16 IDEController = 5;
        public const UInt16 ParallelSCSIHBA = 6;
        public const UInt16 FCHBA = 7;
        public const UInt16 iSCSIHBA = 8;
        public const UInt16 IBHCA = 9;
        public const UInt16 EthernetAdapter = 10;
        public const UInt16 OtherNetworkAdapter = 11;
        public const UInt16 IOSlot = 12;
        public const UInt16 IODevice = 13;
        public const UInt16 FloppyDrive = 14;
        public const UInt16 CDDrive = 15;
        public const UInt16 DVDdrive = 16;
        public const UInt16 Serialport = 17;
        public const UInt16 Parallelport = 18;
        public const UInt16 USBController = 19;
        public const UInt16 GraphicsController = 20;
        public const UInt16 StorageExtent = 21;
        public const UInt16 Disk = 22;
        public const UInt16 Tape = 23;
        public const UInt16 OtherStorageDevice = 24;
        public const UInt16 FirewireController = 25;
        public const UInt16 PartitionableUnit = 26;
        public const UInt16 BasePartitionableUnit = 27;
        public const UInt16 PowerSupply = 28;
        public const UInt16 CoolingDevice = 29;


        public const UInt16 DisketteController = 1;
    }

    public static class ResourceSubType
    {
        // controllers
        public const string ControllerFD = "Microsoft:Hyper-V:Virtual Diskette Controller";
        public const string ControllerSCSI = "Microsoft:Hyper-V:Synthetic SCSI Controller";
        public const string ControllerIDE = "Microsoft:Hyper-V:Emulated IDE Controller";
        public const string ControllerSerial = "Microsoft:Hyper-V:Serial Controller";

        // drives/units
        public const string DiskVirtual = "Microsoft:Hyper-V:Synthetic Disk Drive";
        public const string DiskPhysical = "Microsoft:Hyper-V:Physical Disk Drive";
        public const string DVDVirtual = "Microsoft:Hyper-V:Synthetic DVD Drive";

        // disks/media
        public const string StorageVirtualDVD = "Microsoft:Hyper-V:Virtual CD/DVD Disk";
        public const string StorageVirtualDisk = "Microsoft:Hyper-V:Virtual Hard Disk";
        public const string StoragePhysicalDisk = "Microsoft:Hyper-V:Physical Hard Disk";
        public const string StorageVirtualFD = "Microsoft:Hyper-V:Virtual Floppy Disk";

        // Other
        public const string SerialPort = "Microsoft:Hyper-V:Serial Port";
    }

    public enum ReturnCode : uint
    {
        Completed = 0,
        Started = 4096,
        Failed = 32768,
        AccessDenied = 32769,
        NotSupported = 32770,
        Unknown = 32771,
        Timeout = 32772,
        InvalidParameter = 32773,
        SystemInUse = 32774,
        InvalidState = 32775,
        IncorrectDataType = 32776,
        SystemNotAvailable = 32777,
        OutofMemory = 32778
    }

    public enum JobState : ushort
    {
        New = 2,
        Starting = 3,
        Running = 4,
        Suspended = 5,
        ShuttingDown = 6,
        Completed = 7,
        Terminated = 8,
        Killed = 9,
        Exception = 10,
        Service = 11
    }
}