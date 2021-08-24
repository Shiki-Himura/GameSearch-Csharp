﻿using GameSearch.MvvM;
using GameSearch.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSearch.ViewModels
{
    public class NewEntryViewModel : BaseModel
    {
        private NewEntryCommand _newEntryCommand;
        private string _gameName;
        private string _developer;
        private string _publisher;
        private string _releaseDate;

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


        public NewEntryCommand NewEntryCommand
        {
            get => _newEntryCommand;
            set
            {
                _newEntryCommand = value;
                if (_newEntryCommand.Callback == null)
                {
                    _newEntryCommand.Callback = CreateNewEntry;
                }
            }
        }

        public void CreateNewEntry()
        {
            Navigator.Navigate(typeof(MainView));
        }
    }
}
