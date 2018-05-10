using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    public class MessengerRegisterViewModel:ViewModelBase
    {
        public MessengerRegisterViewModel()
        {
            //构造函数内注册方法 ，每次引用会自动执行该注册方法
            Messenger.Default.Register<string>(this, "message", ShowReceiveInfo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void ShowReceiveInfo(string msg)
        {
            ReceiveInfo += msg + "\n";
        }
        private string receiveInfo;

        public string ReceiveInfo
        {
            get { return receiveInfo; }
            set { receiveInfo = value;RaisePropertyChanged(() => ReceiveInfo); }
        }
        #region 启动新窗口
        private RelayCommand showSenderWindow;

        public RelayCommand ShowSenderWindow
        {
            get
            {
                if (showSenderWindow == null)
                    showSenderWindow = new RelayCommand(() => ExcuteShowSenderWindow());
                return showSenderWindow;
            }
            set
            {
                showSenderWindow = value;
            }
        }
        public void ExcuteShowSenderWindow()
        {
            MessergerSenderView sender = new MessergerSenderView();
            sender.Show();
        }
        #endregion

    }
}
