using System.Diagnostics;
using System.Windows;

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
    }
}
