using MarsRover.ConsoleApp.Models;
using Microsoft.Extensions.Logging;

namespace MarsRover.ConsoleApp.Services
{
    public interface IPlateauService
    {
        Plateau Init(int width, int height);
    }

    public class PlateauService : IPlateauService
    {
        private ILogger _logger;
        public PlateauService(ILogger<PlateauService> logger)
        {
            _logger = logger;
        }
        public Plateau Init(int width, int height)
        {
            Plateau plateau = new Plateau(width, height);
            _logger.LogInformation("Found new plateau!");
            return plateau;
        }
    }
}
