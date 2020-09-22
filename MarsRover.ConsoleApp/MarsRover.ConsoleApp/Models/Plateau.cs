namespace MarsRover.ConsoleApp.Models
{
    public class Plateau
    {
        public Plateau(int width, int height)
        {
            Width = width;
            Height = height;
        }

        private int height {get;set;}
        private int width { get; set; }

        public int Width
        {
            get => width;
            set
            {
                if (value < 0)
                {
                    width = 0;
                    return;
                }
                width = value;
            }
        }

        public int Height
        {
            get => height;
            set
            {
                if (value < 0)
                {
                    height = 0;
                    return;
                }
                    
                height = value;
            }
        }
    }
}
