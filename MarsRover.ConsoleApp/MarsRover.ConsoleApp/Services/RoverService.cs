using MarsRover.ConsoleApp.Factory;
using MarsRover.ConsoleApp.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MarsRover.ConsoleApp.Services
{
    public interface IRoverService
    {
        Rover Init(Plateau plateau, Navigation navigation);
        void SurroundTerrain(List<Navigate> navigates);
    }

    public class RoverService : IRoverService
    {
        private Rover _rover;
        private Plateau _plateau;
        private IRoverCommandFactory _roverCommand;
        private ILogger _logger;

        public RoverService(IRoverCommandFactory roverCommand, ILogger<RoverService> logger)
        {
            _roverCommand = roverCommand;
            _logger = logger;
        }

        public Rover Init(Plateau plateau, Navigation navigation)
        {
            _logger.LogInformation("Initialized new Rover");
            CheckNavigation(plateau, navigation);
            _plateau = plateau;
            return _rover = new Rover(navigation);
        }

        public void SurroundTerrain(List<Navigate> navigates)
        {
            _logger.LogInformation("Surrounding plateau with new directions");
            foreach (var item in navigates)
            {
                _roverCommand.NavigateRover(item).ExecuteCommand(_rover.Navigation);
                CheckNavigation(_plateau, _rover.Navigation);
                _logger.LogInformation(string.Format("Rovers new directions X: {0} Y: {1} Direction: {2}", _rover.Navigation.X, _rover.Navigation.Y, _rover.Navigation.Direction));

            }
        }

        private void CheckNavigation(Plateau plateau, Navigation navigation)
        {
            _logger.LogInformation("Checking plateau and navigation");
            if (plateau.Height < navigation.Y || plateau.Width < navigation.X || navigation.X < 0 || navigation.Y < 0)
                throw new Exception("The Rover was destroyed because such an area could not be found on the plateau.");
        }

    }
}
