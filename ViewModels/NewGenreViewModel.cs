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
    public class NewGenreViewModel : BaseModel
    {
        private GenreData _genreData;
        private string _genreName;

        public Navigator Navigator { get; }
        public RelayCommand CreateGenreCommand { get; set; }

        public string GenreName
        {
            get => _genreName;
            set
            {
                _genreName = value;
                NotifyPropertyChanged("GenreName");
            }
        }

        public void CreateNewGenre(object parameter)
        {
            _genreData.CreateGenre(GenreName);
            Navigator.Navigate<NewEntryView>();
        }
        public bool CanCreateNewGenre(object parameter)
        {
            return GenreName.Length > 0;
        }

        public NewGenreViewModel(Navigator navigator, GenreData genreData)
        {
            _genreData = genreData;
            Navigator = navigator;
            CreateGenreCommand = new RelayCommand(CreateNewGenre, CanCreateNewGenre);
            GenreName = "";
        }
    }
}
