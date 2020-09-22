using MarsRover.ConsoleApp.Factory;
using MarsRover.ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace MarsRover.ConsoleApp
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;

        public static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<MarsRoverApplication>().Run();
            DisposeServices();
            Console.ReadLine();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddLogging(configure => configure.AddConsole())
                .AddTransient<MarsRoverApplication>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IRoverCommandFactory, RoverCommandFactory>();
            services.AddSingleton<IRoverService, RoverService>();
            services.AddSingleton<IPlateauService, PlateauService>();
            services.AddSingleton<MarsRoverApplication>();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
                return;
            if (_serviceProvider is IDisposable)
                ((IDisposable)_serviceProvider).Dispose();
        }
    }
}
