using DBConnection.Data;
using GameSearch.MvvM;
using GameSearch.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSearch.ViewModels
{
    public class NewDeveloperViewModel : BaseModel
    {
        #region Private Fields        
        private DeveloperData _devData;
        private string _developerName;
        #endregion

        #region public Variables        
        public Navigator Navigator { get; }
        public RelayCommand CreateDeveloperCommand { get; set; }
        public string DeveloperName
        {
            get => _developerName;
            set
            {
                _developerName = value;
                NotifyPropertyChanged("DeveloperName");
            }
        }
        #endregion

        #region Methods        
        public void CreateNewDeveloper(object parameter)
        {
            _devData.CreateDeveloper(DeveloperName);
            Navigator.Navigate<NewEntryView>();
        }

        public bool CanCreateNewDeveloper(object parameter)
        {
            return DeveloperName.Length > 0;
        }
        #endregion

        #region Constructor        
        public NewDeveloperViewModel(Navigator navigator, DeveloperData developerData)
        {
            _devData = developerData;
            Navigator = navigator;
            CreateDeveloperCommand = new RelayCommand(CreateNewDeveloper, CanCreateNewDeveloper);
            DeveloperName = "";
        }
        #endregion

    }
}
