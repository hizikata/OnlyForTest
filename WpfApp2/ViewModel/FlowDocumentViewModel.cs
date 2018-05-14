using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using System.Threading;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Threading;
using System.Windows;

namespace WpfApp2.ViewModel
{
    public class FlowDocumentViewModel:ViewModelBase
    {
        public event EventHandler<ValueEventArgs> CreatProgress;
        int _progressBarValue=0;
        public int ProgressBarValue {
            get
            {
                return _progressBarValue;
            }
            set
            {
                _progressBarValue=value;
                RaisePropertyChanged(() => ProgressBarValue);
            }
        }
        public FlowDocumentViewModel()
        {

            DispatcherHelper.Initialize();
        }
        public RelayCommand<object> TestCommand
        {
            get
            {
                return new RelayCommand<object>(obj => ExecuteTest(obj));
            }
        }

        private void ExecuteTest(object obj)
        {
            this.CreatProgress += FlowDocumentViewModel_CreatProgress;
            this.Creat();
        }

        private void Creat()
        {
            Thread thread = new Thread(Start);
            thread.Start();
        }

        private void Start()
        {
            for(int i = 0; i <= 100; i++)
            {
                CreatProgress?.Invoke(this, new ValueEventArgs(i) );
                Thread.Sleep(100);
            }
            MessageBox.Show("载入完成！", "系统提示");
            
        }

        private void FlowDocumentViewModel_CreatProgress(object sender, ValueEventArgs e)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                    ProgressBarValue =e.Value ;
                    
            });
        }
    }
    public class ValueEventArgs : EventArgs
    {
        public int Value;
        public ValueEventArgs(int i)
        {
            Value = i;
        }
    }
}
