using DBConnection.Data;
using DBConnection.Models;
using GameSearch.MvvM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSearch.ViewModels
{
    public class ShellViewModel : BaseModel
    {
        public Navigator Navigator { get; }

        public ShellViewModel(Navigator navigator)
        {
            Navigator = navigator;
        }
    }
}
