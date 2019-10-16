using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Processor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Process[] _processes = Process.GetProcesses();

        public MainWindow()
        {
            InitializeComponent();
            ListProcesses();
        }

        public void ListProcesses()
        {
            var processes =
                from process in _processes
                orderby process.ProcessName
                select new ProcessInfo(process);

            ProcessGrid.ItemsSource = processes;
        }

        private void ProcessGrid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var process = Util.GetSelectedProcess(sender as DataGrid, _processes);

            if (Util.GetProcessWindow(process) == null)
            {
                new ProcessWindow(process).Show();
            }
        }

        private void ProcessGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var process = Util.GetSelectedProcess(sender as DataGrid, _processes);
            var window = Util.GetProcessWindow(process);
            window?.RefreshValues();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Topmost = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Topmost = false;
        }
    }
}
