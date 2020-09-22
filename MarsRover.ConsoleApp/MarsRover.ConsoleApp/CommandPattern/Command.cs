using MarsRover.ConsoleApp.Models;

namespace MarsRover.ConsoleApp.CommandPattern
{
    public abstract class Command
    {
        public abstract void ExecuteCommand(Navigation navigation);
    }

    public class RotateLeft : Command
    {
        public override void ExecuteCommand(Navigation navigation)
        {
            switch (navigation.Direction)
            {
                case CardinalDirection.N:
                    navigation.Direction = CardinalDirection.W;
                    break;
                case CardinalDirection.S:
                    navigation.Direction = CardinalDirection.E;
                    break;
                case CardinalDirection.W:
                    navigation.Direction = CardinalDirection.S;
                    break;
                case CardinalDirection.E:
                    navigation.Direction = CardinalDirection.N;
                    break;
            }
        }
    }

    public class RotateRight : Command
    {
        public override void ExecuteCommand(Navigation navigation)
        {
            switch (navigation.Direction)
            {
                case CardinalDirection.N:
                    navigation.Direction = CardinalDirection.E;
                    break;
                case CardinalDirection.E:
                    navigation.Direction = CardinalDirection.S;
                    break;
                case CardinalDirection.S:
                    navigation.Direction = CardinalDirection.W;
                    break;
                case CardinalDirection.W:
                    navigation.Direction = CardinalDirection.N;
                    break;
            }
        }
    }

    public class MoveForward : Command
    {
        public override void ExecuteCommand(Navigation navigation)
        {
            switch (navigation.Direction)
            {
                case CardinalDirection.N:
                    navigation.Y += 1;
                    break;
                case CardinalDirection.E:
                    navigation.X += 1;
                    break;
                case CardinalDirection.S:
                    navigation.Y -= 1;
                    break;
                case CardinalDirection.W:
                    navigation.X -= 1;
                    break;
            }
        }
    }
}
