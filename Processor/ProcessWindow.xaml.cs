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
            StartTime.Content = _process.StartTime;
            Runtime.Content = DateTime.Now - _process.StartTime;

            // TODO: CPU, RAM, Threads
        }
    }
}
