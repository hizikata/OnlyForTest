using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2;

namespace WpfApp3
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void Mydel(string location);
        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnWriteText_Click(object sender, RoutedEventArgs e)
        {
            Mydel mydel=new Mydel(WriteText);
            mydel += WriteText;
            mydel =(Mydel) Delegate.Remove(mydel,new Mydel(WriteText));
            if (rbtn1.IsChecked==true)
                mydel("tb1");
            if (rbtn2.IsChecked == true)
                mydel("tb2");
            this.tbContent.Focus();
            tbContent.SelectAll(); 
        }
        private void WriteText(string location)
        {
            switch (location)
            {
                case "tb1":
                    tb1.AppendText(tbContent.Text);
                    break;
                case "tb2":
                    tb2.AppendText(tbContent.Text);
                    break;
                default:
                    break;
            }
        }

    }
}
