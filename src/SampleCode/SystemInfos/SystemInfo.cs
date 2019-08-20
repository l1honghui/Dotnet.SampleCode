using System;
using System.Diagnostics;

namespace SampleCode.SystemInfos
{
    class SystemInfo
    {
        public static void PrintSystemInfo()
        {
            var proc = Process.GetCurrentProcess();
            var mem = proc.WorkingSet64;
            var cpu = proc.TotalProcessorTime;
            
            //foreach (var aProc in Process.GetProcesses())
            //    Console.WriteLine("Proc {0,30}  CPU {1,-20:n} msec", aProc.ProcessName, cpu.TotalMilliseconds/Environment.ProcessorCount);

            Console.WriteLine("My process {0} used working set {1:n3} Mb of working set and CPU {2:n} msec",
                proc.ProcessName, mem / 1024.0 / 1024.0,
                cpu.TotalMilliseconds / Environment.ProcessorCount);
        }
    }
    
}