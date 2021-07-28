using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using VeLib;

namespace VeUI
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddMediatR(typeof(MediatrEntryPoint).Assembly);
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            var mainWindowViewModel = serviceProvider.GetService<MainWindowViewModel>();
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
        }
    }   
}