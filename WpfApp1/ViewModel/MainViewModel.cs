using GalaSoft.MvvmLight;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        private MainWindowModel _MainWindow;
        public MainWindowModel MainWindow
        {
            get { return _MainWindow; }
            set { _MainWindow = value;RaisePropertyChanged(() => MainWindow); }
        }
        public MainViewModel()
        {
            MainWindow = new MainWindowModel()
            {
                Introduction = "hello world!"
            };
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        
        }
    }
}