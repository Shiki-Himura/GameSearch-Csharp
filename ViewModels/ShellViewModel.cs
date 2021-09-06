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

        #endregion

        #region Public Variables

        public Navigator Navigator { get; }
        public RelayCommand ShutDownCommand { get; set; }

        #endregion

        #region Methods

        public void ShutdownApp(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }

        #endregion

        #region Constructor

        public ShellViewModel(Navigator navigator)
        {
            ShutDownCommand = new RelayCommand(ShutdownApp, null);
            Navigator = navigator;
        }

        #endregion
    }
}
