using E.Controllers;
using EntityModel;
using Microsoft.Extensions.Logging;
using Moq;
using WebApplication1.Controllers;

namespace TestProject1
{
    public class WeatherForecastControllerTest
    {

        private readonly WeatherForecastController controller;
        private readonly Mock<ILogger<WeatherForecastController>> loggerMock;
        private readonly Mock<IWeatherContext> weatherMock;

        public WeatherForecastControllerTest()
        {
            loggerMock = new Mock<ILogger<WeatherForecastController>>();
            weatherMock = new Mock<IWeatherContext>();
            controller = new WeatherForecastController(loggerMock.Object, weatherMock.Object);
        }
        [Fact]
        public void GetTest()
        {

        }
    }
}