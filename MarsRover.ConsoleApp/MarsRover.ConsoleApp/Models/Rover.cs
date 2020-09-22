using System;

namespace MarsRover.ConsoleApp.Models
{
    public class Rover
    {
        public Rover(Navigation navigation)
        {
            Navigation = navigation;
        }

        public Guid Id { get => Guid.NewGuid(); }
        public Navigation Navigation { get; set; }
    }
}
