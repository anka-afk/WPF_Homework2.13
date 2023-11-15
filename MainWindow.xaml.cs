using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace WPF_Homework2._13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private bool Direct = true;
        private bool isStopping = false;
        private bool firstCheck = true;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void tickfunc(object sender, EventArgs e)
        {
            if (!isStopping)
            {
                if (label1.FontSize <= 48 && Direct == true)
                {
                    label1.FontSize++;
                }
                if (label1.FontSize == 48)
                {
                    Direct = false;
                }
                if (label1.FontSize >= 24 && Direct == false)
                {
                    label1.FontSize--;
                }
                if (label1.FontSize == 24)
                {
                    Direct = true;
                }
            }
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if (firstCheck)
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Tick += new EventHandler(tickfunc);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
                firstCheck = false;
            }
            isStopping = false;
        }

        private void buttonEnd_Click(object sender, RoutedEventArgs e)
        {
            isStopping = true;
        }
    }
}
