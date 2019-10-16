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
        public ProcessWindow(Process process)
        {
            Process = process;

            InitializeComponent();
            SetValues();
        }

        public Process Process { get; set; }

        private void SetValues()
        {
            StartTime.Content = Process.StartTime;
            RunningTime.Content = DateTime.Now - Process.StartTime;

            // TODO: CPU, RAM, Threads
        }
    }
}
