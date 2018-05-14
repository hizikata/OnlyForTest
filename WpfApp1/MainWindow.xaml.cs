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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        public event EventHandler CreatProgress;
        int count = 0;
        #endregion Fields
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            CreatProgress += MainWindow_CreatProgress;
            this.Creat();
        }

        private void Creat()
        {
            Thread t = new Thread(StartProgress);
            t.Start();
        }

        private void MainWindow_CreatProgress(object sender, EventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)delegate
            {
                pbTest.Value = count;
                count++;
            });

        }

        private void StartProgress()
        {


            for (int i = 0; i <= 100; i++)
            {
                CreatProgress?.Invoke(this, null);
                Thread.Sleep(100);
            }


        }
    }


}


