using MarsRover.ConsoleApp.Models;
using System.Collections.Generic;

namespace MarsRover.ConsoleApp.Services
{
    public interface INavigationService
    {
        Navigation Init(int x, int y, string direction);
        List<Navigate> Movements(string directions);
    }

    public class NavigationService : INavigationService
    {
        public Navigation Init(int x, int y, string direction)
        {
            return new Navigation(x, y, direction);
        }

        public List<Navigate> Movements(string directions)
        {
            List<Navigate> navigates = new List<Navigate>();
            if (!string.IsNullOrWhiteSpace(directions))
            {
                foreach (char item in directions)
                {
                    switch (item)
                    {
                        case (char)Navigate.L:
                            navigates.Add(Navigate.L);
                            break;
                        case (char)Navigate.R:
                            navigates.Add(Navigate.R);
                            break;
                        case (char)Navigate.M:
                            navigates.Add(Navigate.M);
                            break;
                        default:
                            throw new System.Exception("No direction found!");
                    }
                }
            }
            return navigates;
        }
    }
}
