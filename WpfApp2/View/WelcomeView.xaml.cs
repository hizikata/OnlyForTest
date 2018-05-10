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
using WpfApp2.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace WpfApp2.View
{
    /// <summary>
    /// WelcomeView.xaml 的交互逻辑
    /// </summary>
    public partial class WelcomeView : Window
    {
        public WelcomeView()
        {
            object a = null;
            InitializeComponent();
            //在构造函数中注册方法，当接受到的信息匹配时执行相应委托。参数意义依次为(收信人，标识信息，委托)
            //泛型用于标识信息的类型
            Messenger.Default.Register<string>(this, "ViewAlert",((string s)=>{ShowReciveInfo(s,a); }));
            this.DataContext = new WelcomeViewModel();
            this.Unloaded += (sender, e) => Messenger.Default.Unregister(this);
        }
        public void ShowReciveInfo(string msg,object a)
        {
            MessageBox.Show(msg);
        }
    }
}
