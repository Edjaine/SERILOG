using System;
using Destructurama.Attributed;

namespace POC_LOG
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [LogMasked]
        public string Summary { get; set; }
    }
}
