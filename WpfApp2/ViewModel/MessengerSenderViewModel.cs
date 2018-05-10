using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;

namespace WpfApp2.ViewModel
{
    public class MessengerSenderViewModel:ViewModelBase
    {
        public MessengerSenderViewModel()
        {

        }
        private string senderInfo;

        public string SenderInfo
        {
            get { return senderInfo; }
            set { senderInfo = value; RaisePropertyChanged(SenderInfo); }
        }
        private RelayCommand senderCommand;
        public RelayCommand SenderCommand
        {
            get
            {
                if (senderCommand == null)
                    senderCommand = new RelayCommand(() => ExcuteSenderCommand());
                return senderCommand;
            }
            set { senderCommand = value; }
        }
        public void ExcuteSenderCommand()
        {
            Messenger.Default.Send<string>(SenderInfo, "message");
        }


    }
}
