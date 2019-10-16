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
            RefreshValues();
        }

        public Process Process { get; set; }

        public void RefreshValues()
        {
            StartTime.Content = Process.StartTime;
            Runtime.Content = DateTime.Now - Process.StartTime;

            // TODO: CPU, RAM, Threads
        }
    }
}
