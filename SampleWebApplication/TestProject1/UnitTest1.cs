using Microsoft.Extensions.Logging;
using SampleWebApplication.Controllers;

namespace TestProject1
{
    public class Tests
    {
        private readonly ILogger<WeatherForecastController> logger;

        public Tests()
        {
            var loggerFactory = new LoggerFactory();
            logger = loggerFactory.CreateLogger<WeatherForecastController>();
        }

        public Tests(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<WeatherForecastController>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            var tgt = new WeatherForecastController(logger);
            var res = tgt.Get();
            Assert.That(res.Count(), Is.EqualTo(5));
        }
    }
}