﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
                select new ProcessInfo
                {
                    Id = process.Id,
                    Name = process.ProcessName,
                    RAM = (new PerformanceCounter("Process", "Working Set", process.ProcessName)).ToString(),
                    CPU = (new PerformanceCounter("Process", "% Processor Time", process.ProcessName)).ToString(),
                    //TODO find a way to resolve access denied
                    //StartTime = process.StartTime,
                    //RunTime = DateTime.Now.Subtract(process.StartTime)

                };

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
            var sb = new StringBuilder();

            sb
                .Append("Start time: ")
                .Append(process.StartTime)
                .Append("\n")
                .Append("Running time: ")
                .Append(DateTime.Now - process.StartTime);

            MessageBox.Show(sb.ToString());

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
    }
}
