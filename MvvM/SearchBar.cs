using GameSearch.MvvM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSearch.ViewModels
{
    public class SearchBar : BaseModel
    {
        private string _searchString;

        public string SearchString
        {
            get => _searchString;
            set
            {
                _searchString = value;
                NotifyPropertyChanged("SearchString");
            }
        }
    }
}
