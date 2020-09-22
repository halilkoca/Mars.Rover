using MarsRover.ConsoleApp.CommandPattern;
using MarsRover.ConsoleApp.Models;

namespace MarsRover.ConsoleApp.Factory
{
    public interface IRoverCommandFactory
    {
        Command NavigateRover(Navigate navigate);
    }

    public class RoverCommandFactory : IRoverCommandFactory
    {
        public Command NavigateRover(Navigate navigate)
        {
            switch (navigate)
            {
                case Navigate.L:
                    return new RotateLeft();
                case Navigate.R:
                    return new RotateRight();
                case Navigate.M:
                    return new MoveForward();
                default:
                    throw new System.Exception("No navigate found!");
            }
        }
    }
}
