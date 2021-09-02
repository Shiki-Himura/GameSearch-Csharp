using GameSearch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameSearch.Views
{
    /// <summary>
    /// Interaktionslogik für NewDeveloperView.xaml
    /// </summary>
    public partial class NewDeveloperView : Page
    {
        public NewDeveloperViewModel NewDeveloperViewModel { get; set; }
        public NewDeveloperView(NewDeveloperViewModel newDeveloperViewModel)
        {
            NewDeveloperViewModel = newDeveloperViewModel;
            InitializeComponent();
        }        
    }
}
