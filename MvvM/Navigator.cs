using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameSearch.MvvM
{
    public class Navigator : BaseModel
    {
        private IServiceProvider _serviceProvider;
        private NavigationCommand _navigationCommand;
        private Page _activePage;

        public Page ActivePage
        {
            get => _activePage;
            set
            {
                _activePage = value;
                NotifyPropertyChanged("ActivePage");
            }
        }

        public NavigationCommand NavigationCommand
        {
            get => _navigationCommand;
            set
            {
                _navigationCommand = value;

                if (_navigationCommand.Callback == null)
                {
                    _navigationCommand.Callback = Navigate;
                }
            }
        }

        public Navigator(IServiceProvider serviceProvider, NavigationCommand navigationCommand)
        {
            _serviceProvider = serviceProvider;
            NavigationCommand = navigationCommand;
        }

        public void Navigate(Type type)
        {
            ActivePage = (Page)_serviceProvider.GetRequiredService(type);
        }
    }
}
