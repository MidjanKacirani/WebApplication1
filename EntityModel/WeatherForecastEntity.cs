namespace EntityModel
{
    public class WeatherForecastEntity
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Temperature { get; set; }
        public WeatherSummary WeatherSummary { get; set; } = new WeatherSummary();
    }
}