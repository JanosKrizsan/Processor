using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
            var process = Util.GetSelectedProcess(sender as DataGrid);

            if (Util.GetProcessWindow(process) == null)
            {
                new ProcessWindow(process).Show();
            }
        }

        private void ProcessGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var process = Util.GetSelectedProcess(sender as DataGrid);
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

        private void SearchInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string uriString = $"http://www.google.com/search?q={SearchInput.Text}";
            
            if (string.IsNullOrWhiteSpace(SearchInput.Text))
            {
                return;
            }

            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Process.Start(uriString);
                SearchInput.Clear();
            }
        }
    }
}
