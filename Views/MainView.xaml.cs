using GameSearch.ViewModels;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace GameSearch.Views
{
    /// <summary>
    /// Interaktionslogik für MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        public MainViewModel MainViewModel { get; set; }

        public MainView(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            InitializeComponent();
        }
    }
}
