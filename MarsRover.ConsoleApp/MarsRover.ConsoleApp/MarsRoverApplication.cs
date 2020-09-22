using MarsRover.ConsoleApp.Models;
using MarsRover.ConsoleApp.Services;
using System.Collections.Generic;

namespace MarsRover.ConsoleApp
{
    class MarsRoverApplication
    {
        private readonly IRoverService _roverService;
        private readonly IPlateauService _plateauService;
        private readonly INavigationService _navigationService;
        public MarsRoverApplication(IRoverService roverService, IPlateauService plateauService
            , INavigationService navigationService)
        {
            _roverService = roverService;
            _plateauService = plateauService;
            _navigationService = navigationService;
        }

        public void Run()
        {
            Plateau plateau = _plateauService.Init(5, 5);
            List<Rover> rovers = new List<Rover>();

            Navigation navigation = _navigationService.Init(1, 2, "N");
            rovers.Add(_roverService.Init(plateau, navigation));
            List<Navigate> navigates = _navigationService.Movements("LMLMLMLMM");
            _roverService.SurroundTerrain(navigates);

            navigation = _navigationService.Init(3, 3, "E");
            rovers.Add(_roverService.Init(plateau, navigation));
            navigates = _navigationService.Movements("MMRMMRMRRM");
            _roverService.SurroundTerrain(navigates);

        }
    }
}
