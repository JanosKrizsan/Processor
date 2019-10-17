using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;


namespace Processor
{
    /// <summary>
    /// Interaction logic for ThreadsWindow.xaml
    /// </summary>
    public partial class ThreadsWindow : Window
    {

        public ThreadsWindow(Process process)
        {
            InitializeComponent();
            SetupValues(process);
            ShowDialog();
        }

        private void SetupValues(Process process)
        {
            List<string> ThreadsListSource = new List<string>();
            Title = process.ProcessName + " Thread List";
            ThreadsListSource.Add($"Your current threads for {process.ProcessName}:");
            foreach(ProcessThread thread in process.Threads)
            {
                ThreadsListSource.Add($"ID: {thread.Id} || State: {thread.ThreadState} || Current Priority: {thread.CurrentPriority}  || Start Time: {thread.StartTime} || Start Address: {thread.StartAddress}");
            }
            ThreadsListSource.Add($"-----------END-OF-REPORT-----------:");

            ThreadsList.ItemsSource = ThreadsListSource;
        }
    }
}
