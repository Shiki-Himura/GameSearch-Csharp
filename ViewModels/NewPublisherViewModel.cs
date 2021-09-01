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
    public class NewPublisherViewModel : BaseModel
    {
        private PublisherData _pubData;
        private string _publisherName;

        public Navigator Navigator { get; }
        public RelayCommand CreatePublisherCommand { get; set; }

        public string PublisherName
        {
            get => _publisherName;
            set
            {
                _publisherName = value;
                NotifyPropertyChanged("PublisherName");
            }
        }

        public void CreateNewPublisher(object parameter)
        {
            _pubData.CreatePublisher(PublisherName);
            Navigator.Navigate<NewEntryView>();
        }

        public bool CanCreateNewPublisher(object parameter)
        {
            return PublisherName.Length > 0;
        }

        public NewPublisherViewModel(Navigator navigator, PublisherData publisherData)
        {
            _pubData = publisherData;
            Navigator = navigator;
            CreatePublisherCommand = new RelayCommand(CreateNewPublisher, CanCreateNewPublisher);
            PublisherName = "";
        }
    }
}
