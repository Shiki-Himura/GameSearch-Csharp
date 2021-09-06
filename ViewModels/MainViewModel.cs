using DBConnection.Data;
using DBConnection.Models;
using GameSearch.MvvM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameSearch.ViewModels
{
    public class MainViewModel : BaseModel
    {
        #region Private Fields

        private GameData _gameListData;
        private List<GamesList> _games;
        private ObservableCollection<GamesList> _data;

        #endregion

        #region Public Variables

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

        #endregion

        #region Constructor

        public MainViewModel(GameData gameData)
        {
            _gameListData = gameData;
            Games = _gameListData.GetAllGames();
        }

        #endregion
    }
}
