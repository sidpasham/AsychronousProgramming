using System;
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
        CancellationTokenSource cts = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSync_Click(object sender, RoutedEventArgs e)
        {
            UtilMethods util = new UtilMethods();
            var websitecontents = util.GetWebsiteContentLengthSync();

            listBox.ItemsSource = websitecontents;
        }

        private void btnasynchronous_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnparallelasynchronous_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
