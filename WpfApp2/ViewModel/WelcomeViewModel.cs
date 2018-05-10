using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using WpfApp2.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    public class WelcomeViewModel:ViewModelBase
    {
        private WelcomeModel _welcome;

        public WelcomeModel Welcome
        {
            get { return _welcome; }
            set { _welcome = value; RaisePropertyChanged(() => Welcome); }
        }
        public WelcomeViewModel()
        {
            Welcome = new WelcomeModel() { Introduction = "My name is Lilith" };
        }
        //发送信息，在Messenger中匹配已注册的方法??如有匹配，执行相应注册方法，否则不做任何操作
        private RelayCommand sendcommand;
        public RelayCommand SendCommand
        {
            get
            {
                if (sendcommand == null)
                    sendcommand = new RelayCommand(() => ExcuteSendCommand());
                return sendcommand;
            }
            set { sendcommand = value; }
        }
        public void ExcuteSendCommand()
        {
            Messenger.Default.Send<string>("ViewModel通知View弹出消息框", "ViewAlert");
        }

    }
}
