using GameSearch.MvvM;
using GameSearch.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameSearch.ViewModels
{
    public class NewEntryViewModel : BaseModel
    {
        private string _gameName;
        private string _developer;
        private string _publisher;
        private string _releaseDate;
        public RelayCommand NewEntryCommand { get; set; }
        public RelayCommand CancelCreateNewEntryCommand { get; set; }

        public Navigator Navigator { get; }

        public string GameName
        {
            get => _gameName;
            set
            {
                _gameName = value;
                NotifyPropertyChanged("GameName");
            }
        }

        public string Developer
        {
            get => _developer;
            set
            {
                _developer = value;
                NotifyPropertyChanged("Developer");
            }
        }

        public string Publisher
        {
            get => _publisher;
            set
            {
                _publisher = value;
                NotifyPropertyChanged("Publisher");
            }
        }

        public string ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
                NotifyPropertyChanged("ReleaseDate");
            }
        }

        public void CreateNewEntry(object parameter)
        {
            Navigator.Navigate<MainView>();
        }
        
        public void CancelCreateNewEntry(object parameter)
        {
            MessageBoxResult result = MessageBoxResult.Yes;

            if (GameName.Length > 0 || Developer.Length > 0 || Publisher.Length > 0 || ReleaseDate.Length > 0)
            {
                result = MessageBox.Show("Unsaved Data! Continue?", "Warning!", MessageBoxButton.YesNo);
            }

            if (result == MessageBoxResult.Yes)
                Navigator.Navigate<MainView>();
        }

        public bool CanCreateNewEntry(object parameter)
        {
            return GameName.Length > 0 && Developer.Length > 0 && Publisher.Length > 0 && ReleaseDate.Length > 0;
        }

        public NewEntryViewModel(Navigator navigator)
        {
            Navigator = navigator;
            NewEntryCommand = new RelayCommand(CreateNewEntry, CanCreateNewEntry);
            CancelCreateNewEntryCommand = new RelayCommand(CancelCreateNewEntry, null);
            GameName = "";
            Developer = "";
            Publisher = "";
            ReleaseDate = "";
        }
    }
}
