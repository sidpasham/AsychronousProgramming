﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncPrograming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cts;
        private UtilMethods util;
        public MainWindow()
        {
            InitializeComponent();
            cts = new CancellationTokenSource();
            util = new UtilMethods();
        }

        private void btnSync_Click(object sender, RoutedEventArgs e)
        {
            Progress<ProgressBarModel> progress = new Progress<ProgressBarModel>();
            progress.ProgressChanged += ReportProgress;
            DisplayContentInListBox(util.GetWebsiteContentLengthSync(progress));
        }

        private void ReportProgress(object sender, ProgressBarModel e)
        {
            ProgressBar bar = new ProgressBar();
            bar.Value = e.ProgressPercentage;
            listBox.ItemsSource = e.ProgressMesssage + Environment.NewLine;
        }

        private async void btnasynchronous_Click(object sender, RoutedEventArgs e)
        {
            DisplayContentInListBox(await util.GetWebsiteContentLengthAsync());
        }

        private async void btnparallelasynchronous_Click(object sender, RoutedEventArgs e)
        {            
            DisplayContentInListBox(await util.GetWebsiteContentLengthParallelAsync());
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DisplayContentInListBox(List<string> lstcontent)
        {
            listBox.ItemsSource = lstcontent;
        }
    }
}
