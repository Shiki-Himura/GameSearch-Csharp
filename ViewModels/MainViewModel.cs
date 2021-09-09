using DBConnection.Data;
using DBConnection.Models;
using GameSearch.MvvM;
using GameSearch.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace GameSearch.ViewModels
{
    public class MainViewModel : BaseModel
    {
        #region Private Fields

        private List<GamesList> _games;
        private ObservableCollection<GamesList> _data;
        private SearchBar _searchBar;

        #endregion

        #region public Variables

        public List<GamesList> Games
        {
            get => _games;
            set
            {
                _games = value;
                Data = new ObservableCollection<GamesList>(_games);
            }
        }
        public ObservableCollection<GamesList> Data
        {
            get => _data;
            set
            {
                _data = value;
                NotifyPropertyChanged("Data");
            }
        }

        public SearchBar SearchBar => _searchBar;

        #endregion

        #region Methods

        public void RefreshDataGrid()
        {
            var filtered = _games.Where(x => x.Name.Contains(SearchBar.SearchString, StringComparison.CurrentCultureIgnoreCase));
            Data = new ObservableCollection<GamesList>(filtered);
        }

        #endregion

        #region Constructor

        public MainViewModel(GameData gameData, SearchBar searchBar)
        {
            _searchBar = searchBar;
            Games = gameData.GetAllGames();
            _searchBar._refreshDataGrid = RefreshDataGrid;
        }

        #endregion
    }
}
