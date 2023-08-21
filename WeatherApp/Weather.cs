using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Weather
    {
        // The temperature, humidity, and description of the specified city
        public double Temperature { get; set; }
        public double LowTemperature { get; set; }
        public double HighTemperature { get; set; }
        public double FeelsLikeTemperature { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }
        public string? Description { get; set; }
        public int Timezone { get; set; }

        // Location information
        public string? LocationName { get; set; }
        public string? Country { get; set; }
    }
}
