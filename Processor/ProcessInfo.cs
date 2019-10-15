﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    internal struct ProcessInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan RunTime { get; set; }
    }
}
