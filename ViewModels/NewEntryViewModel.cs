using DBConnection.Data;
using DBConnection.Models;
using GameSearch.MvvM;
using GameSearch.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GameSearch.ViewModels
{
    public class NewEntryViewModel : BaseModel
    {
        private GameData _gameData;
        private DeveloperData _devData;
        private PublisherData _pubData;
        private Dev_PubData _devPubData;

        private string _gameName;
        private ObservableCollection<Developer> _devList;
        private ObservableCollection<Publisher> _pubList;
        private List<Developer> _developer;
        private List<Publisher> _publisher;
        private DateTime _releaseDate = DateTime.Now;
        private int _devListSelectedIndex;
        private int _pubListSelectedIndex;

        public Navigator Navigator { get; }
        public RelayCommand NewEntryCommand { get; set; }
        public RelayCommand CancelCreateNewEntryCommand { get; set; }

        public List<Developer> Developer
        {
            get => _developer;
            set
            {
                _developer = value;
                DeveloperList = new ObservableCollection<Developer>(_developer);
            }
        }
        public List<Publisher> Publisher
        {
            get => _publisher;
            set
            {
                _publisher = value;
                PublisherList = new ObservableCollection<Publisher>(_publisher);
            }
        }
        public string GameName
        {
            get => _gameName;
            set
            {
                _gameName = value;
                NotifyPropertyChanged("GameName");
            }
        }
        public ObservableCollection<Developer> DeveloperList
        {
            get => _devList;
            set
            {
                _devList = value;
                NotifyPropertyChanged("Developer");
            }
        }
        public ObservableCollection<Publisher> PublisherList
        {
            get => _pubList;
            set
            {
                _pubList = value;
                NotifyPropertyChanged("Publisher");
            }
        }
        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
                NotifyPropertyChanged("ReleaseDate");
            }
        }
        public int DevListSelectedIndex
        {
            get => _devListSelectedIndex;
            set
            {
                _devListSelectedIndex = value;
                NotifyPropertyChanged("DevListSelectedIndex");
            }
        }
        public int PubListSelectedIndex
        {
            get => _pubListSelectedIndex;
            set
            {
                _pubListSelectedIndex = value;
                NotifyPropertyChanged("PubListSelectedIndex");
            }
        }

        public void CreateNewEntry(object parameter)
        {
            _devPubData.CreateDevPub(Developer[DevListSelectedIndex].ID, Publisher[PubListSelectedIndex].ID);
            int id = _devPubData.GetID(Developer[DevListSelectedIndex].ID, Publisher[PubListSelectedIndex].ID);
            _gameData.CreateGame(GameName, id, ReleaseDate);

            Navigator.Navigate<MainView>();
        }

        public void CancelCreateNewEntry(object parameter)
        {
            MessageBoxResult result = MessageBoxResult.Yes;

            if (DevListSelectedIndex > -1 && PubListSelectedIndex > -1)
                result = MessageBox.Show("Unsaved Data! Continue?", "Warning!", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                Navigator.Navigate<MainView>();
        }

        public bool CanCreateNewEntry(object parameter)
        {
            return DevListSelectedIndex > -1 && PubListSelectedIndex > -1;
        }

        public NewEntryViewModel(Navigator navigator, GameData gameData, DeveloperData developerData, PublisherData publisherData, Dev_PubData dev_PubData)
        {
            _gameData = gameData;
            _devData = developerData;
            _pubData = publisherData;
            _devPubData = dev_PubData;
            Publisher = _pubData.GetAllPublisher();
            Developer = _devData.GetAllDeveloper();
            DevListSelectedIndex = -1;
            PubListSelectedIndex = -1;

            Navigator = navigator;
            NewEntryCommand = new RelayCommand(CreateNewEntry, CanCreateNewEntry);
            CancelCreateNewEntryCommand = new RelayCommand(CancelCreateNewEntry, null);
            GameName = "";
        }
    }
}
