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
                if (window is ProcessWindow pWindow && pWindow.ProcessId == process.Id)
                {
                    return pWindow;
                }
            }

            return null;
        }

        public static Process GetSelectedProcess(DataGrid processGrid)
        {
            if (processGrid.SelectedItem == null)
            {
                return null;
            }

            var selected = (ProcessInfo) processGrid.SelectedItem;

            return Process.GetProcessById(selected.Id);
        }
    }
}
