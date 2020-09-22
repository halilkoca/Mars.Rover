using MarsRover.ConsoleApp.Models;
using MarsRover.ConsoleApp.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MarsRover.ConsoleApp
{
    class MarsRoverApplication
    {
        private readonly IRoverService _roverService;
        private readonly IPlateauService _plateauService;
        private readonly INavigationService _navigationService;
        private readonly ILogger _logger;
        public MarsRoverApplication(IRoverService roverService, IPlateauService plateauService
            , INavigationService navigationService, ILogger<MarsRoverApplication> logger)
        {
            _roverService = roverService;
            _plateauService = plateauService;
            _navigationService = navigationService;
            _logger = logger;
        }

        public void Run()
        {
            try
            {
                _logger.LogInformation("Mars Rover Application Started...");

                Plateau plateau = _plateauService.Init(5, 5);
                List<Rover> rovers = new List<Rover>();

                // First Rover
                Navigation navigation = _navigationService.Init(1, 2, "N");
                Rover rover1 = _roverService.Init(plateau, navigation);
                rovers.Add(rover1);
                List<Navigate> navigates = _navigationService.Movements("LMLMLMLMM");
                _roverService.SurroundTerrain(navigates);

                // Second Rover
                navigation = _navigationService.Init(3, 3, "E");
                Rover rover2 = _roverService.Init(plateau, navigation);
                rovers.Add(rover2);
                navigates = _navigationService.Movements("MMRMMRMRRM");
                _roverService.SurroundTerrain(navigates);

                // Third Rover - with errors
                navigation = _navigationService.Init(5, 5, "N");
                Rover rover3 = _roverService.Init(plateau, navigation);
                rovers.Add(rover3);
                navigates = _navigationService.Movements("MMRMMRMRRM");
                _roverService.SurroundTerrain(navigates);

            }
            catch (System.Exception ex)
            {
                // Global Exception Handling
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
