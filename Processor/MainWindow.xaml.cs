using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Processor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Process[] processes = Process.GetProcesses();


        public MainWindow()
        {
            InitializeComponent();
            listProcesses();
        }

        public void listProcesses()
        {
            var query =
                from process in processes
                orderby process.ProcessName
                select new
                {
                    process.ProcessName,
                    process.PagedMemorySize64,
                    process.PeakPagedMemorySize64,
                    process.Id
                };

            ProcessGrid.ItemsSource = query.ToList();
        }
    }
}
