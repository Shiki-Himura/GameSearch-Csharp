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
        #region Private Fields

        private GameData _gameData;
        private DeveloperData _devData;
        private PublisherData _pubData;
        private GenreData _genreData;
        private Dev_PubData _devPubData;
        private string _gameName;
        private ObservableCollection<Developer> _devList;
        private ObservableCollection<Publisher> _pubList;
        private ObservableCollection<Genre> _genreList;
        private List<Developer> _developer;
        private List<Publisher> _publisher;
        private List<Genre> _genre;
        private DateTime _releaseDate = DateTime.Now;
        private int _devListSelectedIndex;
        private int _pubListSelectedIndex;
        private int _genreListSelectedIndex;
        #endregion

        #region public Variables        
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
        public List<Genre> Genre
        {
            get => _genre;
            set
            {
                _genre = value;
                GenreList = new ObservableCollection<Genre>(_genre);
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
        public ObservableCollection<Genre> GenreList
        {
            get => _genreList;
            set
            {
                _genreList = value;
                NotifyPropertyChanged("Genre");
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
        public int GenreListSelectedIndex
        {
            get => _genreListSelectedIndex;
            set
            {
                _genreListSelectedIndex = value;
                NotifyPropertyChanged("GenreListSelectedIndex");
            }
        }
        #endregion

        #region Methods        
        public void CreateNewEntry(object parameter)
        {
            _devPubData.CreateDevPub(Developer[DevListSelectedIndex].ID, Publisher[PubListSelectedIndex].ID);
            int dev_pubID = _devPubData.GetID(Developer[DevListSelectedIndex].ID, Publisher[PubListSelectedIndex].ID);

            _gameData.CreateGame(GameName, GenreList[GenreListSelectedIndex].ID, dev_pubID, ReleaseDate);

            Navigator.Navigate<MainView>();
        }

        public void CancelCreateNewEntry(object parameter)
        {
            MessageBoxResult result = MessageBoxResult.Yes;

            if (DevListSelectedIndex > -1 || PubListSelectedIndex > -1 || _gameName.Length > 0)
                result = MessageBox.Show("Unsaved Data! Continue?", "Warning!", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                Navigator.Navigate<MainView>();
        }

        public bool CanCreateNewEntry(object parameter)
        {
            return DevListSelectedIndex > -1 && PubListSelectedIndex > -1 && _gameName.Length > 0;
        }
        #endregion

        #region Constructor
        public NewEntryViewModel(Navigator navigator, GameData gameData, DeveloperData developerData, PublisherData publisherData, Dev_PubData dev_PubData, GenreData genreData)
        {
            _gameData = gameData;
            _devData = developerData;
            _pubData = publisherData;
            _devPubData = dev_PubData;
            _genreData = genreData;
            Publisher = _pubData.GetAllPublisher();
            Developer = _devData.GetAllDeveloper();
            Genre = _genreData.GetAllGenre();
            DevListSelectedIndex = -1;
            PubListSelectedIndex = -1;
            GenreListSelectedIndex = -1;

            Navigator = navigator;
            NewEntryCommand = new RelayCommand(CreateNewEntry, CanCreateNewEntry);
            CancelCreateNewEntryCommand = new RelayCommand(CancelCreateNewEntry, null);
            GameName = "";
        }
        #endregion
    }
}
