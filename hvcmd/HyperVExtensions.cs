#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.Versioning;

namespace LTR.HyperV;

internal static class InternalExtensions
{
    public static string JoinMessages(this Exception ex, string delim = " -> ") => string.Join(delim, ex.EnumerateMessages());

    public static IEnumerable<string> EnumerateMessages(this Exception ex) => ex.Enumerate().Select(x => x.Message);

    public static IEnumerable<Exception> Enumerate(this Exception? ex)
    {
        while (ex is not null)
        {
            if (ex is AggregateException aex)
            {
                foreach (var tex in aex.InnerExceptions.SelectMany(iex => iex.Enumerate()))
                {
                    yield return tex;
                }

                break;
            }

            if (ex is TargetInvocationException)
            {
            }
            else
            {
                yield return ex;
            }

            ex = ex.InnerException;
        }
    }
}

public static class HyperVExtensions
{
#if NETCOREAPP
    [SupportedOSPlatform("windows")]
#endif
    public static void Refresh(this ManagementBaseObject? obj) => (obj as ManagementObject)?.Get();
}
