namespace WeatherForecastAPI.Models {
    public class WeatherForecast {
        public DateTime Date  {get; set;}
        public int TemperatureC  {get; set;}


        // Tính toán temperature in Fahrenheit
        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        public string Summary {get; set;}
    }
}