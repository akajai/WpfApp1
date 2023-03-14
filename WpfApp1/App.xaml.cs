using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfApp1.DBContext;
using WpfApp1.Services;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        //public App()
        //{
        //    this.InitializeComponent();
        //    var services = new ServiceCollection();
        //    services.AddScoped<MainWindow>();
        //    services.AddDbContext<AppDbContext>();
        //    services.AddScoped<ControlServices>();
        //    _serviceProvider = services.BuildServiceProvider();
        //}

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        //    mainWindow.Show();
        //}

    }
}
