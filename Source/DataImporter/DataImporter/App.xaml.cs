using DataImporter.Services;
using DataImporter.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace DataImporter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public IServiceProvider ServiceProvider { get; private set; }


        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<DataImporterViewModel>();
            services.AddSingleton<BaseViewModel>();
            services.AddTransient<MainWindow>();
            services.WithCoreServices();

        }
    }
}
