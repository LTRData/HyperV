# HyperV

Windows command-line tool and .NET library for managing Hyper-V through the [Hyper-V WMI v2 provider](https://learn.microsoft.com/en-us/windows/win32/hyperv_v2/windows-virtualization-portal).

The single [hvcmd project](hvcmd/hvcmd.csproj) builds the `hvcmd` executable and supplies the API packaged as [LTRData.HyperV](https://www.nuget.org/packages/LTRData.HyperV). The C# namespace is `LTR.HyperV`.

## Requirements

- Windows is required for both the CLI and library, including when managing a remote host. The platform-neutral framework names do not imply Linux or macOS support.
- The target host must expose the Hyper-V WMI namespace `root\virtualization\v2`.
- Run under a Windows identity authorized to query or manage Hyper-V on the target. Local administrative operations may require an elevated terminal.
- Remote access uses WMI/DCOM and the current Windows identity; the CLI has no username/password switches. Host permissions, firewall rules and authentication must allow the connection. See Microsoft's [remote WMI setup guidance](https://learn.microsoft.com/en-us/windows/win32/wmisdk/connecting-to-wmi-remotely-starting-with-vista).
- Available operations depend on the host's WMI provider, VM generation, VM state and guest integration services.

## Build

Use the .NET 10 SDK for the current source tree. To build just the .NET 10 executable:

```sh
dotnet build hvcmd/hvcmd.csproj -c Debug -f net10.0
```

From the repository root, show the built-in help or list local machines:

```powershell
dotnet .\Debug\net10.0\hvcmd.dll /?
dotnet .\Debug\net10.0\hvcmd.dll LIST
```

The project targets `net45`, `net8.0`, `net9.0`, `net10.0`, `netstandard2.0` and `netstandard2.1`, with a `System.Management` package dependency. Select a runnable .NET target for the CLI; .NET Standard provides library compatibility targets.

Outputs go under `Debug/<framework>/` or `Release/<framework>/`. Release builds also generate NuGet packages; `LocalNuGetPath` controls the package output directory. A full multi-target build requires the corresponding framework reference assemblies.

## Command-line usage

The general form is:

```text
hvcmd [/TRACE] [\\host] command arguments...
```

The examples below assume `hvcmd.exe` is on PATH. Alternatively, use `dotnet` with the built DLL path as above. Commands are case-insensitive. `machine` means the VM's display name (`ElementName`); quote names containing spaces. Omit `\\host` for the local computer. If used, `/TRACE` goes first.

```powershell
hvcmd LIST
hvcmd QUERY "Example VM"
hvcmd LISTCTRL "Example VM"
hvcmd LISTSWITCHES
hvcmd \\hyperv-host LIST
hvcmd \\hyperv-host QUERY "Example VM"
```

### Commands

| Commands | Purpose |
| --- | --- |
| `LIST`, `QUERY machine` | List VM names, states and uptime, or print a VM's WMI properties. |
| `LISTCTRL machine [resourceSubtype [className]]` | List controllers, or children of controllers matching a resource subtype. |
| `START machine`, `SAVESTATE machine`, `PAUSE machine` | Request the corresponding VM state. |
| `SHUTDOWN machine [FORCE]` | Request guest shutdown through the shutdown integration component. |
| `RESET machine`, `TURNOFF machine` | Reset or power off the VM without a graceful guest shutdown. |
| `CREATEVM machine [disk [memorymb [cpus]]]` | Create a Generation 1 VM with network adapters and an IDE DVD drive; optionally attach an existing virtual disk or a numeric host physical-disk number. |
| `DESTROYVM machine` | Destroy the VM through the management provider. |
| `ADDSCSI machine`, `ADDVNIC machine`, `ADDENIC machine` | Add a SCSI controller, synthetic NIC or emulated NIC. |
| `ADDSWITCH name`, `LISTSWITCHES` | Create an internal virtual switch, or list switches and port information. |
| `IDEDVD`, `IDEVHD`, `SCSIVHD` | Add image media to an existing device on the selected controller. |
| `SCSIDVD`, `FD` | Add SCSI DVD or floppy drive/media resources. |
| `IDEPHD`, `SCSIPHD` | Attach a host physical disk to an IDE or SCSI controller. |
| `CONVERTVHD source target FIXED\|DYNAMIC VHD\|VHDX` | Request virtual-disk conversion through Hyper-V's image management service. |

The built-in help lists only part of the implemented command set. See [HyperVCommands.cs](hvcmd/HyperVCommands.cs) for media/controller argument handling. In particular, `IDEPHD` and `SCSIPHD` parse `machine hostdrivenumber [deviceNumber [controllerNumber]]`: the device-number argument is consumed but not passed to the attachment operation, and the default controller number is 1.

Commands that change state or configuration act without a confirmation prompt. `SHUTDOWN` requires a usable guest shutdown component; `TURNOFF` and `RESET` can discard unsaved guest work. Disk paths must identify files accessible to the target Hyper-V host; use absolute paths for remote operations.

The CLI's `CREATEVM` always selects Generation 1. It adds synthetic and emulated NICs but does not connect them to a switch. It attaches the supplied disk rather than creating a new disk image. The library exposes generation selection separately.

## Using the library

```sh
dotnet add package LTRData.HyperV
```

For example, enumerate local VMs from a Windows application:

```csharp
using System;
using LTR.HyperV;

var scope = HyperVSupportRoutines.GetManagementScope(@"\\.");

foreach (var machine in HyperVSupportRoutines.GetTargetComputers(scope))
{
    using (machine)
    {
        Console.WriteLine($"{machine.ElementName}: {(VirtualMachineState)machine.EnabledState}");
    }
}
```

Pass `@"\\hyperv-host"` to select another host.

| Source | Role |
| --- | --- |
| [HyperVTasks.cs](hvcmd/HyperVTasks.cs) | Task-based state changes, VM creation/destruction, storage and switch operations, with job progress and cancellation parameters. |
| [HyperVSupportRoutines.cs](hvcmd/HyperVSupportRoutines.cs) | WMI scopes, VM/resource lookup, controller queries and property inspection. |
| [HyperVCommands.cs](hvcmd/HyperVCommands.cs) | Argument-oriented command handlers used by the CLI. |
| [Management/ROOT/virtualization/v2](hvcmd/Management/ROOT/virtualization/v2) | Typed wrappers for Hyper-V WMI classes. The separate `Management/Unused` sources are excluded from compilation. |

Operations returning `uint` expose provider result codes; asynchronous job failures raise `JobFailedException`. A cancellation token can stop waiting for a job; it does not roll back the operation or request cancellation of the underlying Hyper-V job.
