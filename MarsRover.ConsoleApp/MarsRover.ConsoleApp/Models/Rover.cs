using System;

namespace MarsRover.ConsoleApp.Models
{
    public class Rover
    {
        public Rover(Navigation navigation)
        {
            Navigation = navigation;
        }

        public Navigation Navigation { get; set; }
    }
}
