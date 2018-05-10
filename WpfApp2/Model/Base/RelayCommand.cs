using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfApp2.Model.Base
{
    public class RelayCommand : ICommand
    {
        #region Fields
        readonly Predicate<object> _canExecute;
        readonly Action<object> _execute;
        #endregion

        #region Constructor
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentException("execute");
            this._canExecute = canExecute;
            this._execute = execute;
        }
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
            
        }
        #endregion


        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
             return (this._canExecute == null)? true : _canExecute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            this._execute(parameter);
        }
    }
}
