using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace WeatherApp
{
    public class WeatherService
    {
        // The API key for accessing the OpenWeatherMap API
        private const string apiKey = "c28dc3e330d705d02ea3c70645e4afcf";
        public async Task<(Weather, string)> GetWeather(string city, string unit)
        {
            // Create variable to hold the URL for the weather data
            string url;

            // Condition checks if the user input a zip code or a city name
            if (IsZipCode(city))
            {
                url = $"http://api.openweathermap.org/data/2.5/weather?zip={city}&appid={apiKey}&units={unit}";
            }
            else
            {
                url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units={unit}";
            }

            using (HttpClient httpClient = new HttpClient())
            {
                // create a new http response message
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // get the json string after a response is received
                    string json = await response.Content.ReadAsStringAsync();

                    // create a json document by parsing "json"
                    JsonDocument weatherData = JsonDocument.Parse(json);

                    // Extract each property from the json document
                    string? weatherDescription = weatherData.RootElement.GetProperty("weather")[0].GetProperty("description").GetString();
                    if (weatherDescription == null)
                    {
                        Console.WriteLine("No weather description available.");
                    }
                    // Getting the variables for each of the weather object attributes
                    double temperature = Math.Round(weatherData.RootElement.GetProperty("main").GetProperty("temp").GetDouble(), 1);
                    double lowTemperature = Math.Round(weatherData.RootElement.GetProperty("main").GetProperty("temp_min").GetDouble(), 1);
                    double highTemperature = Math.Round(weatherData.RootElement.GetProperty("main").GetProperty("temp_max").GetDouble(), 1);
                    double feelsLikeTemperature = Math.Round(weatherData.RootElement.GetProperty("main").GetProperty("feels_like").GetDouble(), 1);
                    double humidity = Math.Round(weatherData.RootElement.GetProperty("main").GetProperty("humidity").GetDouble(), 1);
                    long sunriseTimestamp = weatherData.RootElement.GetProperty("sys").GetProperty("sunrise").GetInt64();
                    long sunsetTimestamp = weatherData.RootElement.GetProperty("sys").GetProperty("sunset").GetInt64();
                    double windSpeed = Math.Round(weatherData.RootElement.GetProperty("wind").GetProperty("speed").GetDouble(), 1);
                    string? locationName = weatherData.RootElement.GetProperty("name").GetString();
                    string? country = weatherData.RootElement.GetProperty("sys").GetProperty("country").GetString();
                    int timezone = weatherData.RootElement.GetProperty("timezone").GetInt32();

                    // converting timezone data for sunrise/sunset b/c json has in UNIX

                    // "offset" the # of seconds offset for specific city timezone
                    TimeSpan offset = TimeSpan.FromSeconds(timezone);

                    // Offset for Sunrise
                    DateTimeOffset dateTimeOffsetSunrise = DateTimeOffset.FromUnixTimeSeconds(sunriseTimestamp).ToOffset(offset);

                    // Offset for Sunset
                    DateTimeOffset dateTimeOffsetSunset = DateTimeOffset.FromUnixTimeSeconds(sunsetTimestamp).ToOffset(offset);

                    // Getting the adjusted date/time for sunrise and sunset
                    DateTime sunrise = dateTimeOffsetSunrise.DateTime;
                    DateTime sunset = dateTimeOffsetSunset.DateTime;
                    
                    // Create new "Weather" object to return values
                    // and returns the entire json 
                    return (new Weather
                    {
                        Description = weatherDescription,
                        Temperature = temperature,
                        Humidity = humidity,
                        LocationName = locationName,
                        Country = country,
                        LowTemperature = lowTemperature,
                        HighTemperature = highTemperature,
                        FeelsLikeTemperature = feelsLikeTemperature,
                        Sunrise = sunrise,
                        Sunset = sunset,
                        WindSpeed = windSpeed
                    }, json);

                }
                else
                {
                    throw new Exception("Error fetching API weather data.");
                }
                
            }

        }
        // Checks if the passed string is composed of all numbers
        private bool IsZipCode(string code)
        {
            return code.All(char.IsDigit);
        }
    }
}
