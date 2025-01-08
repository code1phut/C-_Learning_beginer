using Microsoft.AspNetCore.Mvc;
using WeatherForecastAPI.Models;

namespace WeatherForecastApi.Controllers {
    [ApiController]
    [Route("api/[controller]")]

    public class WeatherForecastController : ControllerBase {
        private static readonly string[] Summaries = new[]
        {
            "Ha Noi", "Ho Chi Minh", "Da Nang", "Nha Trang", "Phu Quoc", "Ha Nam", "Thai Binh", "Nam Dinh", "Hung Yen", "Yen Bai"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


// GET: api/weatherforecast
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // GET: api/weatherforecast/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 0 || id > 10)
            {
                return NotFound();
            }

            var weather = new WeatherForecast
            {
                Date = DateTime.Now.AddDays(id),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            return Ok(weather);
        }

        // POST: api/weatherforecast
        [HttpPost]
        public IActionResult CreateWeather([FromBody] WeatherForecast weatherForecast)
        {
            if (weatherForecast == null)
            {
                return BadRequest();
            }

            _logger.LogInformation($"New weather forecast created: {weatherForecast.Summary}");

            // Mô phỏng lưu dữ liệu
            return CreatedAtAction(nameof(GetById), new { id = 1 }, weatherForecast);
        }
    }
}