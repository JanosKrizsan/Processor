using System;
using System.Diagnostics;
using System.Windows;

namespace Processor
{
    /// <summary>
    /// Interaction logic for ProcessWindow.xaml
    /// </summary>
    public partial class ProcessWindow : Window
    {
        public Process Process { get; set; }

        public string RAM { get; private set; }
        public string CPU { get; private set; }

        private readonly PerformanceCounter RamCounter;
        private readonly PerformanceCounter CpuCounter;

        public ProcessWindow(Process process)
        {
            RAM = "0 MB";
            CPU = "0 %";
            RamCounter = new PerformanceCounter("Process", "Private Bytes", process.ProcessName, true);
            CpuCounter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName, true);

            Process = process;
            InitializeComponent();
            SetValues();
        }


        private void SetValues()
        {
            StartTime.Content = Process.StartTime;
            RunningTime.Content = DateTime.Now - Process.StartTime;

            UpdatePerformanceStats();
            RamData.Content = RAM;
            CpuData.Content = CPU;
        }

        public void UpdatePerformanceStats()
        {
            RAM = (Math.Round(RamCounter.NextValue() / 1024 / 1024, 2)).ToString() + " MB";
            CPU = (Math.Round(CpuCounter.NextValue() / Environment.ProcessorCount, 2)).ToString() + " %";
        }
    }
}
