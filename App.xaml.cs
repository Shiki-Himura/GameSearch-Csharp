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
        }

        private void CreateServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<ShellView>()
                .AddSingleton<ShellViewModel>()
                .AddTransient<MainView>()
                .AddTransient<MainViewModel>()
                .AddTransient<NewEntryView>()
                .AddTransient<NewEntryViewModel>()
                .BuildServiceProvider();

        }
    }
}
