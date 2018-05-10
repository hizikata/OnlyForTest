using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WpfApp2.Model
{
    public class MainModel:ObservableObject
    {
        private string _introduction;
        public string Introduction
        {
            get { return _introduction; }
            set { _introduction = value;RaisePropertyChanged(() => Introduction); }
        }
        

    }
}
