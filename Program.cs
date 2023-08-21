using System;
using System.Net.Http;
using System.Text.Json;

namespace WeatherApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // flag to continue running the program
            bool continueRunning = true;

            // api key for the weather data
            string apiKey = "c28dc3e330d705d02ea3c70645e4afcf";

            while (continueRunning)
            {
                Console.WriteLine("Enter the city you want the weather for: ");
                Console.WriteLine("To exit, type EXIT.");
                string? city = Console.ReadLine();
                
                // validate user input a city
                if (string.IsNullOrWhiteSpace(city))
                {
                    Console.WriteLine($"{city} is an invalid city or no city entered. Please try again.");
                    continue;
                }

                // check if user wants to exit the program
                if (city.ToLower() == "exit")
                {
                    continueRunning = false;
                    continue;
                }

                switch (city)
                {
                    case "exit":
                    continueRunning = false;
                    break;

                    default:
                    // url for the weather api
                    string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
                    
                    // create a new http client
                    HttpClient httpClient = new HttpClient();

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
                        double temperature = weatherData.RootElement.GetProperty("main").GetProperty("temp").GetDouble();
                        double humidity = weatherData.RootElement.GetProperty("main").GetProperty("humidity").GetDouble();

                        // Output each property to the terminal
                        Console.WriteLine($"The weather today in {city} is {weatherDescription}.");
                        Console.WriteLine($"The temperature is currently {temperature}C.");
                        Console.WriteLine($"The humidity is {humidity}%.");
                        
                    }
                    else
                    {
                        Console.WriteLine("Error fetching API weather data.");
                    }
                    break;

                }
 
            }
        }
    }
}