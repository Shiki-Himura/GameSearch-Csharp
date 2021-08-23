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
    /// Interaktionslogik für NewEntryView.xaml
    /// </summary>
    public partial class NewEntryView : Page
    {
        public NewEntryViewModel NewEntryViewModel { get; set; }
        public NewEntryView(NewEntryViewModel newEntryViewModel)
        {
            NewEntryViewModel = newEntryViewModel;
            InitializeComponent();
        }
    }
}
