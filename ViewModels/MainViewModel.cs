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

        private GameData _gameListData;
        private SearchBar _searchBar;
        private List<GamesList> _games;
        private ObservableCollection<GamesList> _data;

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


        #region Constructor

        public MainViewModel(GameData gameData, SearchBar searchBar)
        {
            _gameListData = gameData;
            _searchBar = searchBar;
            Games = _gameListData.GetAllGames();
        }

        #endregion
    }
}
// implement filter with searchbar.searchstring
/*          CollectionViewSource _itemSourceList = new() { Source = MainViewModel.Data };
            ICollectionView ItemList = _itemSourceList.View;

            var filter = new Predicate<object>(item => ((GamesList)item).Name.Contains(SearchBar.Text));
            ItemList.Filter = filter;

            MainView.gameGrid.ItemsSource = ItemList;
 */
