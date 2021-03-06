using DBConnection.Data;
using GameSearch.Logic.FileConverter;
using GameSearch.MvvM;
using GameSearch.ViewModels;
using GameSearch.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GameSearch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CreateServiceProvider();

            _serviceProvider.GetRequiredService<ShellView>().Show();
            _serviceProvider.GetRequiredService<Navigator>().Navigate<MainView>();
        }

        private void CreateServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<ShellView>()
                .AddSingleton<ShellViewModel>()
                .AddSingleton<Navigator>()
                .AddSingleton<GameData>()
                .AddSingleton<GenreData>()
                .AddSingleton<DeveloperData>()
                .AddSingleton<PublisherData>()
                .AddSingleton<Dev_PubData>()
                .AddSingleton<IConverter, JsonConverter>()
                .AddSingleton<IConverter, CsvConverter>()
                .AddSingleton<IConverter, XmlConverter>()
                .AddSingleton<SearchBar>()
                .AddSingleton<MainView>()
                .AddSingleton<MainViewModel>()
                .AddTransient<NewEntryView>()
                .AddTransient<NewEntryViewModel>()
                .AddTransient<NewGenreView>()
                .AddTransient<NewGenreViewModel>()
                .AddTransient<NewDeveloperView>()
                .AddTransient<NewDeveloperViewModel>()
                .AddTransient<NewPublisherView>()
                .AddTransient<NewPublisherViewModel>()
                .AddTransient<NewDataFileView>()
                .AddTransient<NewDataFileViewModel>()
                .BuildServiceProvider();

        }
    }
}
