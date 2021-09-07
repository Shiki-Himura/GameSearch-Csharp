using DBConnection.Data;
using DBConnection.Models;
using GameSearch.MvvM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSearch.ViewModels
{
    public class ShellViewModel : BaseModel
    {
        #region Private Fields(empty)

        private RelayCommand searchBoxCommand;
        private RelayCommand _searchbox;

        #endregion

        #region Public Variables

        public Navigator Navigator { get; }
        public RelayCommand SearchBoxCommand 
        { 
            get => searchBoxCommand;
            set
            {
                _searchbox = value;
                NotifyPropertyChanged("SearchBoxCommand");
            }
        }
        public RelayCommand ShutDownCommand { get; set; }

        #endregion

        #region Methods

        public void FilterGrid(object parameter)
        {
            throw new NotImplementedException();
        }
        public void ShutdownApp(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }

        #endregion

        #region Constructor

        public ShellViewModel(Navigator navigator, RelayCommand searchBoxCommand)
        {
            Navigator = navigator;
            ShutDownCommand = new RelayCommand(ShutdownApp, null);
            SearchBoxCommand = searchBoxCommand;
        }

        #endregion
    }
}
