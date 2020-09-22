using MarsRover.ConsoleApp.Factory;
using MarsRover.ConsoleApp.Models;
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

        public RoverService(IRoverCommandFactory roverCommand)
        {
            _roverCommand = roverCommand;
        }

        public Rover Init(Plateau plateau, Navigation navigation)
        {
            CheckNavigation(plateau, navigation);
            _plateau = plateau;
            return _rover = new Rover(navigation);
        }

        public void SurroundTerrain(List<Navigate> navigates)
        {
            foreach (var item in navigates)
            {
                _roverCommand.NavigateRover(item).ExecuteCommand(_rover.Navigation);
                CheckNavigation(_plateau, _rover.Navigation);
            }
        }

        private void CheckNavigation(Plateau plateau, Navigation navigation)
        {
            if (plateau.Height < navigation.Y || plateau.Width < navigation.X || navigation.X < 0 || navigation.Y < 0)
                throw new Exception("The Rover was destroyed because such an area could not be found on the plateau.");
        }

    }
}
