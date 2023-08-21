using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    /*
    Weather object contains all the variables for the specified city to be displayed on the GUI to the user

    Temperature: The current temperature
    LowTemperature: The lowest temperature of the day
    HighTemperature: The highest temperature of the day
    FeelsLikeTemperature: What the temperature feels like
    Sunrise: The time of day for sunrise (12-hour time w/ AM-PM)
    Sunset: The time of day for sunset (12-hour time w/ AM-PM)
    WindSpeed: The current wind speed in either MPH or KPH depending on unit selection (imperial/metric)
    Humidity: The humidity of the air as a percentage
    Description: A short description of the current weather
    Timezone: The timezone offset used for getting the sunrise/sunset time for a given location
    LocationName: The name of the town/city specified by the user
    Country: The country the town/city resides within

    */

    public class Weather
    {
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
