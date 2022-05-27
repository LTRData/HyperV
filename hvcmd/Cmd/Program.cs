using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace LTR.HyperV.Cmd;

using Management.ROOT.virtualization.v2;
using static HyperVCommands;

public static class Program
	{
    [STAThread]
		internal static int Main(string[] args)
		{
			if (args.Length == 0 || args[0] == "/?")
			{
				Console.WriteLine(string.Join(
                Environment.NewLine, new[]
                {
                    @"HVCMD [\\host] LIST",
					    @"HVCMD [\\host] QUERY machine",
					    @"HVCMD [\\host] START machine",
					    @"HVCMD [\\host] SAVESTATE machine",
					    @"HVCMD [\\host] PAUSE machine",
					    @"HVCMD [\\host] RESET machine",
					    @"HVCMD [\\host] TURNOFF machine",
					    @"HVCMD [\\host] SHUTDOWN machine [FORCE]",
                    @"HVCMD [\\host] FD machine imagepath",
                    @"HVCMD [\\host] IDEDVD machine imagepath devicenumber [controllernumber]",
                    @"HVCMD [\\host] SCSIDVD machine imagepath devicenumber [controllernumber]",
                    @"HVCMD [\\host] IDEVHD machine imagepath devicenumber [controllernumber]",
                    @"HVCMD [\\host] SCSIVHD machine imagepath devicenumber [controllernumber]",
                    @"HVCMD [\\host] IDEPHD machine hostdrivenumber [controllernumber]",
                    @"HVCMD [\\host] SCSIPHD machine hostdrivenumber [controllernumber]",
                    @"HVCMD [\\host] CREATEVM machine vhdpath memorymb cpus",
                    @"HVCMD [\\host] CONVERTVHD sourceimage targetimage FIXED|DYNAMIC VHD|VHDX"
                }));
				return 0;
			}

        var argslist = new List<string>(args);
			int exitcode;

#if NETFRAMEWORK || NETCOREAPP
        if (argslist.Count > 0 && argslist[0].Equals("/TRACE", StringComparison.InvariantCultureIgnoreCase))
        {
            Trace.Listeners.Add(new ConsoleTraceListener(useErrorStream: true));
            argslist.RemoveAt(0);
        }
#endif

        try
			{
				var rc = CommandParser(argslist).Result;

				if (HyperVSupportRoutines.Messages.TryGetValue(rc, out var message))
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine($"Error code: {rc}");
            }

            exitcode = unchecked((int)rc);
			}
			catch (Exception ex)
			{
            Trace.WriteLine(ex.ToString());
#if DEBUG
            Console.Error.WriteLine(ex.ToString());
#else
            Console.Error.WriteLine(ex.JoinMessages());
#endif

            if (ex is JobFailedException)
            {
                exitcode = (ex as JobFailedException).ErrorCode;
            }
            else
            {
                exitcode = -1;
            }
        }

        if (Debugger.IsAttached)
        {
            Console.ReadKey();
        }

        return exitcode;
		}

    public static Task<uint> CommandParser(List<string> args)
    {
        if (args.Count == 0)
        {
            throw new Exception("Required parameter missing.");
        }

        string remoteMachine;
        if (args[0].StartsWith("\\\\"))
        {
            remoteMachine = args[0];
            args.RemoveAt(0);
        }
        else
        {
            remoteMachine = "\\\\.";
        }

        if (args.Count == 0)
        {
            args.Add("list");
        }

        var cmd = args[0].ToLowerInvariant();
        args.RemoveAt(0);

        var scope = HyperVSupportRoutines.GetManagementScope(remoteMachine);

        var cancel = new CancellationTokenSource();

        Console.CancelKeyPress += (sender, e) => cancel.Cancel();

        return cmd switch
        {
            "list" => cmdList(scope, args),
            "start" => cmdChangeState(scope, args, VirtualMachineState.Running, JobProgress, cancel.Token),
            "savestate" => cmdChangeState(scope, args, VirtualMachineState.Saved_state, JobProgress, cancel.Token),
            "pause" => cmdChangeState(scope, args, VirtualMachineState.Paused, JobProgress, cancel.Token),
            "reset" => cmdChangeState(scope, args, VirtualMachineState.Resetting, JobProgress, cancel.Token),
            "turnoff" => cmdChangeState(scope, args, VirtualMachineState.Off, JobProgress, cancel.Token),
            "shutdown" => cmdShutdown(scope, args),
            "query" => cmdQuery(scope, args),
            "fd" => cmdFD(scope, args, JobProgress, cancel.Token),
            "idedvd" => cmdIDEDVD(scope, args, JobProgress, cancel.Token),
            "scsidvd" => cmdSCSIDVD(scope, args, JobProgress, cancel.Token),
            "idevhd" => cmdIDEVHD(scope, args, JobProgress, cancel.Token),
            "scsivhd" => cmdSCSIVHD(scope, args, JobProgress, cancel.Token),
            "idephd" => cmdIDEPHD(scope, args, JobProgress, cancel.Token),
            "scsiphd" => cmdSCSIPHD(scope, args, JobProgress, cancel.Token),
            "listctrl" => cmdLISTCTRL(scope, args),
            "convertvhd" => cmdConvertVHD(scope, args, JobProgress, cancel.Token),
            "createvm" => cmdCreateVM(scope, args, JobProgress, cancel.Token),
            "destroyvm" => cmdDestroyVM(scope, args, JobProgress, cancel.Token),
            "addscsi" => cmdCreateSCSI(scope, args, JobProgress, cancel.Token),
            "addvnic" => cmdAddVNIC(scope, args, JobProgress, cancel.Token),
            "addenic" => cmdAddENIC(scope, args, JobProgress, cancel.Token),
            "addswitch" => cmdAddSwitch(scope, args, JobProgress, cancel.Token),
            "listswitches" => cmdListSwitches(scope, args, JobProgress, cancel.Token),
            _ => throw new Exception("Unknown command."),
        };
    }

    public static Task JobProgress(ConcreteJob Job, CancellationToken cancellationToken)
    {
        Console.Write($"In progress... {Job.PercentComplete}% completed.\r");

        if ((JobState)Job.JobState is JobState.Starting
            or JobState.Running)
        {
            Console.Write("\r");
            return Task.Delay(500, cancellationToken);
        }
        else
        {
            Console.WriteLine();
            return Task.FromResult(0);
        }
    }
}
