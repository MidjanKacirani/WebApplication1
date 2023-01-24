using EntityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherContext db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var query = db.WeatherForecast.Select(x => new WeatherForecast()
            {
                Date = x.Date,
                Summary = x.WeatherSummary.Name,
                TemperatureC = x.Temperature
            });

            return query.ToList();
        }

        [HttpGet("/LogIn/{username}/{password}")]
        public bool LogIn(string username, string password)
        {
            return db.Users.Any(x => x.Username == username && x.Password == password);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Post(WeatherForecast input)
        {
            var summary = db.WeatherSummary.FirstOrDefault(x => x.Name == input.Summary);

            if (summary == null) return NotFound();

            db.WeatherForecast.Add(new WeatherForecastEntity()
            {
                Date = input.Date,
                Temperature = input.TemperatureC,
                WeatherSummary = summary
            });

            db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public ActionResult Put(WeatherForecast input, Guid Id)
        {
            //var summary = db.WeatherSummary.FirstOrDefault(x => x.Name == input.Summary);

            var entity = db.WeatherForecast.FirstOrDefault(x => x.Id == Id);

            if (entity == null) return NotFound();

            entity.Temperature = input.TemperatureC;

            db.SaveChanges();

            return Ok();
        }


    }
}