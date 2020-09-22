using MarsRover.ConsoleApp.Factory;
using MarsRover.ConsoleApp.Models;
using MarsRover.ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections.Generic;

namespace MarsRover.Test
{
    public class RoverServiceTest
    {
        private IRoverService _roverService;

        [SetUp]
        public void Setup()
        {

            var services = ConfigureServices();
            var roverCommandFactory = services.GetService<IRoverCommandFactory>();
            _roverService = new RoverService(roverCommandFactory);

        }

        [Test]
        public void Check_NavigationOutOfPlateau_ThrowsException()
        {

            Plateau plateau = new Plateau(5, 5);
            Navigation navigation = new Navigation(6, 6, "N");
            Assert.Throws<System.Exception>(() => _roverService.Init(plateau, navigation));

        }

        [Test]
        public void Check_NavigatesOutOfPlateau_ThrowsException()
        {

            Plateau plateau = new Plateau(5, 5);
            Navigation navigation = new Navigation(1, 2, "N");
            Rover rover = _roverService.Init(plateau, navigation);
            List<Navigate> directions = new List<Navigate> { Navigate.L, Navigate.M, Navigate.M, Navigate.M, Navigate.M };
            Assert.Throws<System.Exception>(() => _roverService.SurroundTerrain(directions));

        }

        private ServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IRoverCommandFactory, RoverCommandFactory>()
            .AddSingleton<IRoverService, RoverService>()
            .BuildServiceProvider(true);
            return serviceCollection;
        }
    }
}