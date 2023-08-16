using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTicketBookingSystem.Interfaces;
using SimpleTicketBookingSystem.Service;
//using SimpleTicketBookingSystem.Services;
using SimpleTicketBookingSystem.UI;
//using PeanutButter.TinyEventAggregator;
using SimpleTicketBookingSystem.Data;

namespace SampleShopApp.App;

public class Program
{


   [STAThread]
   public static void Main(string[] args)
   {
        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        var mainScreen = ServiceProvider.GetRequiredService<MainScreen>();
        mainScreen.Show();

   }

    public static IServiceProvider? ServiceProvider { get; private set; } = null;
    #region Properties And Methods

    /// <summary>
    /// Service provider.
    /// </summary>


    /// <summary>
    /// Creates a host builder.
    /// </summary>
    /// <returns></returns>
    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainScreen, MainScreen>();
                services.AddSingleton<SelectSeatsScreen, SelectSeatsScreen>();
                services.AddSingleton<IDataService, DataService>();
                services.AddSingleton<MoviesScreen, MoviesScreen>();

            });
    }

    #endregion // Properties And Methods
}