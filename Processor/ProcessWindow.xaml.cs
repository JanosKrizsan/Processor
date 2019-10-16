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

        public ProcessWindow(Process process)
        {
            Process = process;
            InitializeComponent();
            SetValues();
        }


        private void SetValues()
        {
            StartTime.Content = Process.StartTime;
            RunningTime.Content = DateTime.Now - Process.StartTime;

            PerformanceCounter _RamCounter = new PerformanceCounter("Process", "Private Bytes", Process.ProcessName, true);
            PerformanceCounter _CpuCounter = new PerformanceCounter("Process", "% Processor Time", Process.ProcessName, true);

            RamData.Content = (Math.Round(_RamCounter.NextValue() / 1024 / 1024, 2)) + " MB";
            CpuData.Content = (Math.Round(_CpuCounter.NextValue() / Environment.ProcessorCount, 2)) + " %";

            ThreadData.Content = Process.Threads.Count;
        }
    }
}
