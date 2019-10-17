using System.Diagnostics;
using System.Linq;
using System.Threading;
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
            Util.HandleOpenedCommentsWindow();

            var process = Util.GetSelectedProcess(sender as DataGrid);
            SearchInput.Text = process.ProcessName;

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
            var searchText = SearchInput.Text;
            var uriString = $"http://www.google.com/search?q={searchText}";
            
            if (e.Key != System.Windows.Input.Key.Enter)
            {
                return;

            } else { SearchInput.Clear(); }

            if (string.IsNullOrWhiteSpace(searchText))
            {
                uriString = "https://github.com/JanosKrizsan/Processor";
            }


            //creates a new thread where the new process executes, then promptly stops it, aborting the thread
            Thread searchStrings = new Thread(new ThreadStart(() =>  Process.Start(uriString) ));
            searchStrings.Start();
            Thread.Sleep(10);
            searchStrings.Abort();
        }
    }
}
