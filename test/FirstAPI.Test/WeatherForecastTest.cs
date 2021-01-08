using FirstAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Threading.Tasks;

namespace FirstAPI.Test
{
    public class WeatherForecastTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Sum1And2Returns3()
        {
            var mockRepo = new Mock<ILogger<WeatherForecastController>>();

            var controller = new WeatherForecastController(mockRepo.Object);

            var actionResult = await controller.GetSum(1, 2);
            var okResult = actionResult as OkObjectResult;
            var sum = (long)JsonConvert.DeserializeObject(okResult.Value.ToString());
            Assert.AreEqual(3, sum);
        }
    }
}