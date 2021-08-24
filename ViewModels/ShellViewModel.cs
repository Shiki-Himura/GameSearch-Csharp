using GameSearch.MvvM;
using System;
using System.Collections.Generic;
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
