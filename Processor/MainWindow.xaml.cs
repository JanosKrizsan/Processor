﻿using System;
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

        private void ProcessGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (ProcessGrid.SelectedItem == null)
            {
                return;
            }

            var selected = (ProcessInfo)ProcessGrid.SelectedItem;

            var process = _processes.Single(p => p.Id == selected.Id);
            //var sb = new StringBuilder();

            //int RAM = (int)Math.Round(new PerformanceCounter("Process", "Working Set", process.ProcessName).NextValue());
            //int CPU = (int)Math.Round(new PerformanceCounter("Process", "% Processor Time", process.ProcessName).NextValue());

            //sb
            //    .Append("Start time: ")
            //    .Append(process.StartTime)
            //    .Append("\n")
            //    .Append("Running time: ")
            //    .Append(DateTime.Now - process.StartTime)
            //    .Append("\n")
            //    .Append("RAM Usage: ")
            //    .Append(RAM + " %")
            //    .Append("\n")
            //    .Append("CPU Usage: ")
            //    .Append(CPU + " %");

            //MessageBox.Show(sb.ToString());

            if (!IsWindowOpen(process))
            {
                new ProcessWindow(process).Show();
            }

            ProcessGrid.UnselectAll();

        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Topmost = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Topmost = false;
        }

        private static bool IsWindowOpen(IDisposable process)
        {
            foreach (var window in Application.Current.Windows)
            {
                if (window is ProcessWindow pWindow && Equals(pWindow.Process, process))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
