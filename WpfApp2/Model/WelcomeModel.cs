using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace WpfApp2.Model
{
    public class WelcomeModel:ObservableObject
    {
        private string _introduction;

        public string Introduction
        {
            get { return _introduction; }
            set { _introduction = value; RaisePropertyChanged(() => Introduction); }
        }

    }
}
