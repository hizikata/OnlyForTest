using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WpfApp2.ViewModel
{
    public class CommandViewModel:ViewModelBase
    {
        #region Fields
        public RelayCommand Command { get; set; }
        public string DisplayName { get; set; }
        public ImageSource Image { get; set; }
        public string Remark { get; set; }
        #endregion
        #region Constructors
        public CommandViewModel(RelayCommand command,string displayName,string image,string remark)
        {
            this.Command = command;
            this.DisplayName = displayName;
            ImageSource Image = new BitmapImage(new Uri("pack://application:,,,/WpfApp2;component/Resources/" + image, UriKind.Absolute));
            this.Remark = remark;
        }
        public CommandViewModel(RelayCommand command,string displayName,string image) : this(command, displayName, image, null)
        {

        }
        public CommandViewModel(RelayCommand command,string displayName) : this(command, displayName, null, null)
        {

        }
        #endregion
    }
}
