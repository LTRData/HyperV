#nullable enable

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace LTR.HyperV;

public enum VMGeneration
{
    G1 = 1,
    G2 = 2
}

public static class ResourceType
{
    public const ushort Other = 1;
    public const ushort ComputerSystem = 2;
    public const ushort Processor = 3;
    public const ushort Memory = 4;
    public const ushort IDEController = 5;
    public const ushort ParallelSCSIHBA = 6;
    public const ushort FCHBA = 7;
    public const ushort iSCSIHBA = 8;
    public const ushort IBHCA = 9;
    public const ushort EthernetAdapter = 10;
    public const ushort OtherNetworkAdapter = 11;
    public const ushort IOSlot = 12;
    public const ushort IODevice = 13;
    public const ushort FloppyDrive = 14;
    public const ushort CDDrive = 15;
    public const ushort DVDdrive = 16;
    public const ushort Serialport = 17;
    public const ushort Parallelport = 18;
    public const ushort USBController = 19;
    public const ushort GraphicsController = 20;
    public const ushort StorageExtent = 21;
    public const ushort Disk = 22;
    public const ushort Tape = 23;
    public const ushort OtherStorageDevice = 24;
    public const ushort FirewireController = 25;
    public const ushort PartitionableUnit = 26;
    public const ushort BasePartitionableUnit = 27;
    public const ushort PowerSupply = 28;
    public const ushort CoolingDevice = 29;

    public const ushort DisketteController = 1;
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

[Serializable]
public class VirtualMachineNotFoundException : Exception
{
    public VirtualMachineNotFoundException() { }
    
    public VirtualMachineNotFoundException(string message) : base(message) { }
    
    public VirtualMachineNotFoundException(string message, Exception inner) : base(message, inner) { }

    [Obsolete("Serialization not supported")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected VirtualMachineNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
