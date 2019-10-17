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

        public static void HandleOpenedCommentsWindow()
        {
            var cWindow = GetCommentsWindow();

            if (string.IsNullOrWhiteSpace(cWindow?.NewComment.Text))
            {
                cWindow?.Close();
                return;
            }

            var result = MessageBox.Show($"You have an unsaved comment for {cWindow.ProcessName}.\n\nDo you want to save it?",
                "Alert!", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

            if (result == MessageBoxResult.Yes)
            {
                cWindow.SaveComment();
                MessageBox.Show("Your comment has been saved!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            cWindow.Close();
        }

        private static CommentsForProcess GetCommentsWindow()
        {
            return Application.Current.Windows.OfType<CommentsForProcess>().FirstOrDefault();
        }
    }
}
