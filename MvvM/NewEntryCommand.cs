using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameSearch.MvvM
{
    public class NewEntryCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public Action Callback { get; set; }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (Callback != null)
            {
                Callback.Invoke();
            }
        }
    }
}
