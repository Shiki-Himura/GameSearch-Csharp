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
        private Page _activePage;
        private List<Type> _types;

        public Page ActivePage
        {
            get => _activePage;
            set
            {
                _activePage = value;
                NotifyPropertyChanged("ActivePage");
            }
        }

        public RelayCommand NavigationCommand { get; set; }

        public Navigator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            NavigationCommand = new RelayCommand(Navigate, null);

            _types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass & t.Namespace == "GameSearch.Views")
                .ToList();
        }

        public void Navigate<T>()
        {
            ActivePage = (Page)_serviceProvider.GetRequiredService(typeof(T));
        }        
        public void Navigate(object parameter)
        {
            ActivePage = (Page)_serviceProvider.GetRequiredService(_types.First(x => x.Name == parameter.ToString()));
        }
    }
}
