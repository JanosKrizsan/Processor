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
        private readonly Process _process;

        public ProcessWindow(Process process)
        {
            _process = process;

            InitializeComponent();
            RefreshValues();
        }

        public int ProcessId => _process.Id;

        public void RefreshValues()
        {
            Title = _process.ProcessName;

            StartTime.Content = _process.StartTime;
            Runtime.Content = DateTime.Now - _process.StartTime;

            var ramCounter = new PerformanceCounter("Process", "Private Bytes", _process.ProcessName, true);
            var cpuCounter = new PerformanceCounter("Process", "% Processor Time", _process.ProcessName, true);

            RamData.Content = (Math.Round(ramCounter.NextValue() / 1024 / 1024, 2)) + " MB";
            CpuData.Content = (Math.Round(cpuCounter.NextValue() / Environment.ProcessorCount, 2)) + " %";

            ThreadData.Content = _process.Threads.Count;
        }
    }
}
