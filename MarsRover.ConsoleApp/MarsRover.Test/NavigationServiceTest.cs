using MarsRover.ConsoleApp.Services;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class NavigationServiceTest
    {
        private INavigationService _navigationService;
        [SetUp]
        public void Setup()
        {
            _navigationService = new NavigationService();
        }

        [Test]
        public void Check_DifferentDifferentCardinalNavigation_ThrowsException()
        {

            Assert.Throws<System.Exception>(() => _navigationService.Init(3, 1, "K"));

        }
    }
}