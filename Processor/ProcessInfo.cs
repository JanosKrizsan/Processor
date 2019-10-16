using System;
using System.Diagnostics;
using System.Threading;

namespace Processor
{
    internal struct ProcessInfo
    {
        public int Id { get; }
        public string Name { get; }


        public ProcessInfo(Process process)
        {
            Id = process.Id;
            Name = process.ProcessName;
        }
    }
}
