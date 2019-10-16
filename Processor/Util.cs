using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Processor
{
    internal class Util
    {
        public static ProcessWindow GetProcessWindow(Process process)
        {
            foreach (var window in Application.Current.Windows)
            {
                if (window is ProcessWindow pWindow && Equals(pWindow.Process, process))
                {
                    return pWindow;
                }
            }

            return null;
        }

        public static Process GetSelectedProcess(DataGrid processGrid, Process[] processes)
        {
            if (processGrid.SelectedItem == null)
            {
                return null;
            }

            var selected = (ProcessInfo) processGrid.SelectedItem;

            return processes.SingleOrDefault(p => p.Id == selected.Id);
        }
    }
}
