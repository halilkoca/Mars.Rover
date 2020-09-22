using MarsRover.ConsoleApp.Models;

namespace MarsRover.ConsoleApp.Services
{
    public interface IPlateauService
    {
        Plateau Init(int width, int height);
    }

    public class PlateauService : IPlateauService
    {
        public Plateau Init(int width, int height)
        {
            return new Plateau(width, height);
        }
    }
}
