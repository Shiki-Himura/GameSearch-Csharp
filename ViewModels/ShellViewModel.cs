using GameSearch.MvvM;
using GameSearch.Views;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace GameSearch.ViewModels
{
    public class ShellViewModel : BaseModel
    {
        #region Private Fields

        private SearchBar _searchBar;

        #endregion

        #region Public Variables

        public Navigator Navigator { get; }
        public RelayCommand ShutDownCommand { get; set; }

        public SearchBar SearchBar => _searchBar;

        #endregion

        #region Methods

        public void ShutdownApp(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }

        #endregion

        #region Constructor

        public ShellViewModel(Navigator navigator, SearchBar searchBar)
        {
            Navigator = navigator;
            _searchBar = searchBar;
            ShutDownCommand = new RelayCommand(ShutdownApp, null);
        }

        #endregion
    }
}
