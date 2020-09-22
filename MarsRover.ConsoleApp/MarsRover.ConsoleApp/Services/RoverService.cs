using MarsRover.ConsoleApp.Factory;
using MarsRover.ConsoleApp.Models;
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
        private IRoverCommandFactory _roverCommand;

        public RoverService(IRoverCommandFactory roverCommand)
        {
            _roverCommand = roverCommand;
        }

        public Rover Init(Plateau plateau, Navigation navigation)
        {
            return _rover = new Rover(navigation);
        }

        public void SurroundTerrain(List<Navigate> navigates)
        {
            foreach (var item in navigates)
            {
                _roverCommand.NavigateRover(item).ExecuteCommand(_rover.Navigation);
            }
        }
    }
}
