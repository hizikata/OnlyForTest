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
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using WpfApp2.ViewModel;

namespace WpfApp2.View
{
    /// <summary>
    /// MessengerRegisterView.xaml 的交互逻辑
    /// </summary>
    public partial class MessengerRegisterView : Window
    {
        public MessengerRegisterView()
        {
            InitializeComponent();
            this.DataContext = new MessengerRegisterViewModel();
            this.Unloaded += (sender, e) => Messenger.Default.Unregister(this);
        }
    }
}
