using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class MainWindowModel:ObservableObject
    {
        private string _Introduction;
        public string Introduction
        {
            get { return _Introduction; }
            set { _Introduction = value;RaisePropertyChanged(() => Introduction); }
        }
    }
}
