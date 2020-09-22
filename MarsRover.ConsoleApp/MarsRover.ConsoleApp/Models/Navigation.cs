using System;

namespace MarsRover.ConsoleApp.Models
{
    public class Navigation
    {
        public Navigation(int x, int y, string directionStr)
        {
            X = x;
            Y = y;
            Direction = Enum.TryParse(directionStr, out CardinalDirection direction) ? direction : throw new Exception("No direction found!");
        }

        private int x { get; set; }
        private int y { get; set; }

        public CardinalDirection Direction { get; set; } = CardinalDirection.N;
        public int X
        {
            get => x;
            set
            {
                if (value < 0)
                    x = 0;
                x = value;
            }
        }

        public int Y
        {
            get => y;
            set
            {
                if (value < 0)
                    y = 0;
                y = value;
            }
        }

    }
}
