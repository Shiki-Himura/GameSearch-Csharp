using DBConnection.Data;
using GameSearch.Logic.FileConverter;
using GameSearch.MvvM;
using GameSearch.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameSearch.ViewModels
{
    public class NewDataFileViewModel : BaseModel
    {
        #region Private Fields

        private string _filePath;
        private ObservableCollection<IConverter> _fileType;
        private IConverter _selectedFileType;
        private DeveloperData _developerData;
        private PublisherData _publisherData;
        private GenreData _genreData;
        private GameData _gameData;

        #endregion

        #region Public Variables

        public string FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                NotifyPropertyChanged("FilePath");
            }
        }
        public ObservableCollection<IConverter> FileType
        {
            get => _fileType;
            set
            {
                _fileType = value;
                NotifyPropertyChanged("FileType");
            }
        }
        public IConverter SelectedFileType
        {
            get => _selectedFileType;
            set
            {
                _selectedFileType = value;
                NotifyPropertyChanged("SelectedFileType");
            }
        }

        public Navigator Navigator { get; }
        public RelayCommand CreateFileCommand { get; set; }
        public RelayCommand CancelCreateFileCommand { get; set; }

        #endregion

        #region Methods

        public void CreateFile(object parameter)
        {
            SelectedFileType.CreateFile(FilePath);
        }
        private bool CanCreateFile(object parameter)
        {
            return FilePath?.Length > 0 && SelectedFileType != null;
        }
        private void CancelCreateFile(object parameter)
        {
            MessageBoxResult result = MessageBoxResult.Yes;

            if (FilePath.Length > 0 || SelectedFileType != null)
                result = MessageBox.Show("Unsaved Data! Continue?", "Warning!", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                Navigator.Navigate<MainView>();
        }

        #endregion

        #region Constructor

        public NewDataFileViewModel(DeveloperData developerData,
                                    PublisherData publisherData,
                                    GenreData genreData, GameData gameData,
                                    Navigator navigator,
                                    IEnumerable<IConverter> converters)
        {
            _developerData = developerData;
            _publisherData = publisherData;
            _genreData = genreData;
            _gameData = gameData;
            Navigator = navigator;
            FileType = new ObservableCollection<IConverter>(converters);

            CreateFileCommand = new RelayCommand(CreateFile, CanCreateFile);
            CancelCreateFileCommand = new RelayCommand(CancelCreateFile, null);
        }


        #endregion
    }
}
