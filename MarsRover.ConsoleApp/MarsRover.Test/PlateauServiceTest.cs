using MarsRover.ConsoleApp.Models;
using MarsRover.ConsoleApp.Services;
using NuGet.Frameworks;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class PlateauServiceTest
    {
        private IPlateauService _plateauService;
        [SetUp]
        public void Setup()
        {
            _plateauService = new PlateauService();
        }

        [Test]
        public void Check_SmallerThanZero_ReturnsZero()
        {

            var response = _plateauService.Init(-5, -5);
            Assert.AreEqual(0, response.Height);
            Assert.AreEqual(0, response.Width);

        }
    }
}