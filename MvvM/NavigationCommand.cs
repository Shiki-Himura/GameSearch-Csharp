﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameSearch.MvvM
{
    public class NavigationCommand : ICommand
    {
        private List<Type> _types;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public Action<Type> Callback { get; set; }

        public NavigationCommand()
        {
            _types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass & t.Namespace == "GameSearch.Views")
                .ToList();
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (Callback != null)
            {
                Callback.Invoke(_types.First(x => x.Name == parameter.ToString()));
            }
        }
    }
}
