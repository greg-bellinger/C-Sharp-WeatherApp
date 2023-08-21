using System;
using System.CodeDom.Compiler;
using System.Drawing.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        // Init variables to be used by the form //
        
        // Create a WeatherService object to interact with the weather API and get the data
        private WeatherService weatherService = new WeatherService();

        // Holds the name/zip code of the city to get weather data for
        private string city;

        // Create a Weather object which contains all the data to be displayed
        private Weather weather;

        // Holds the raw json data for weather exporting
        private string rawJson;
        public Form1()
        {
            // Initializes component and empty vars
            InitializeComponent();

            city = string.Empty;
            rawJson = string.Empty;
            weather = new Weather();

            // Sets the title of the window to "Weather App"
            this.Text = "Weather App";

            // Sets the default units to Fahrenheight
            fRadioButton.Checked = true;

            // Sets the "Check Weather" button as default
            // which allows "Enter" to submit city name/zip
            this.AcceptButton = submitButton;

        }

        // Method gets the weather data in the specified units (imperial/metric)
        private async Task FetchAndDisplayWeatherData()
        {
            // "city" is the city name/zip input by the user
            city = inputText.Text;

            // "unit" the unit selection by the user
            string unit = celciusRadioButton.Checked ? "metric" : "imperial";

            // Checks if a city name/zip has been entered in the inputText text area
            if (string.IsNullOrWhiteSpace(city))
            {
                return;
            }

            // Try-catch for building the "Weather" object using the API data
            try
            {
                // get the tuple containing the weather and the json
                (weather, rawJson) = await weatherService.GetWeather(city, unit);

                // Update the labels on the GUI
                temperatureLabel.Text = $"Temperature: {weather.Temperature}°{(unit == "metric" ? "C" : "F")}";
                humidityLabel.Text = $"Humidity: {weather.Humidity}%";
                descriptionLabel.Text = $"Forecast: {weather.Description}";
                locationLabel.Text = $"{weather.LocationName}, {weather.Country}";
                feelsLikeLabel.Text = $"Feels Like: {weather.FeelsLikeTemperature}°{(unit == "metric" ? "C" : "F")}";
                tempLowLabel.Text = $"Low: {weather.LowTemperature}°{(unit == "metric" ? "C" : "F")}";
                tempHighLabel.Text = $"High: {weather.HighTemperature}°{(unit == "metric" ? "C" : "F")}";
                windSpeedLabel.Text = $"Wind Speed: {weather.WindSpeed} {(unit == "metric" ? "km/hr" : "mi/hr")}";

                // Converting the datetime for sunrise/sunset into 12-hr time w/ AM/PM
                DateTime sunriseTime = DateTime.Today.Add(weather.Sunrise.TimeOfDay);
                sunriseLabel.Text = $"Sunrise: {sunriseTime.ToString("hh:mm tt")}";
                DateTime sunsetTime = DateTime.Today.Add(weather.Sunset.TimeOfDay);
                sunsetLabel.Text = $"Sunset: {sunsetTime.ToString("hh:mm tt")}";

            }
            
            // Displays the error message
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Method for getting weather data when submit button is clicked
        private async void submitButton_Click(object sender, EventArgs e)
        {
            await FetchAndDisplayWeatherData();
        }

        // Method clears the input fields and weather records
        // when user clicks on the input box
        private void inputText_Enter(object sender, EventArgs e)
        {
            inputText.Text = string.Empty;
            temperatureLabel.Text = "Temperature: ________";
            humidityLabel.Text = "Humidity: ________";
            descriptionLabel.Text = "Forecast: ________";
            locationLabel.Text = string.Empty;
            tempLowLabel.Text = "Low: ________";
            tempHighLabel.Text = "High: ________";
            feelsLikeLabel.Text = "Feels Like: ________";
            windSpeedLabel.Text = "Wind Speed: ________";
            sunriseLabel.Text = "Sunrise: ________";
            sunsetLabel.Text = "Sunset: ________";

        }

        // Method gets the weather data in Imperial units when selected
        private async void fRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            await FetchAndDisplayWeatherData();
        }

        // Method gets the weather in Metric units when selected
        private async void celciusRadioButton_CheckedChanged(Object sender, EventArgs e)
        {
            await FetchAndDisplayWeatherData();
        }

        // jsonExport_Click creates the ExportForm and displays the dialog box.
        private void jsonExport_Click(object sender, EventArgs e)
        {
            // Check if the weather object is null or if LocationName is not set
            if (weather == null || string.IsNullOrWhiteSpace(weather.LocationName))
            {
                // Show a message box asking the user to enter a city/zip
                MessageBox.Show("Please enter a city or zip code to get the weather data before exporting.", "No Weather Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create the new export form using the weather, city name, and json data
            ExportForm exportForm = new ExportForm(weather, city, rawJson);

            // Display the export form dialog box
            exportForm.ShowDialog();
        }


        // Method exports the weather data to the desired folder determined in the buttonChangeLocation_Click method
        // @Weather weather: the weather object containing the displayed weather information
        // @string city: the city name/zip supplied by the user
        // @string folder: the folder to export the json weather data do
        private void ExportWeatherData(Weather weather, string city, string folder)
        {
            if (weather == null)
            {
                return;
            }

            // Replace any invalid file name characters in the city name to make a valid file path
            string validFileName = string.Join("_", city.Split(System.IO.Path.GetInvalidFileNameChars()));

            // Create a folder for the weather logs
            string folderPath = folder;

            // Ensure the folder exists before trying to add to it
            Directory.CreateDirectory(folderPath);

            // create thename of the file
            string fileName = $"{validFileName}.txt";

            // Creating the entire file path
            string filePath = Path.Combine(folderPath, validFileName);

            // open or create the file, depending on if it exists already
            using (StreamWriter streamWriter = new StreamWriter(filePath, append: true))
            {
                // Write the date and time the weather was logged in the JSON
                streamWriter.WriteLine($"Date and Time: {DateTime.Now}");

                // Parse the raw json string
                JsonDocument jsonDocument = JsonDocument.Parse(rawJson);

                // Serialize the json with indentation to increase readability
                string indentedJson = JsonSerializer.Serialize(jsonDocument, new JsonSerializerOptions { WriteIndented = true });

                // write the JSON string
                streamWriter.Write(indentedJson);

                // Adding a section break between logs
                streamWriter.WriteLine("\n");
                streamWriter.WriteLine(new string('-', 40));
            }
        }
    }
}