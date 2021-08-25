using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameSearch.MvvM
{
    public class RelayCommand : ICommand
    {
        private Action<object> _callback;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _callback?.Invoke(parameter);
        }

        public RelayCommand(Action<object> action, Func<object, bool> func)
        {
            _callback = action;
            _canExecute = func;
        }
    }
}
