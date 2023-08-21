using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class ExportForm : Form
    {
        // Initializes empty variables to be used in the Export Form //

        // The Weather object holds all the weather data displayed on the main GUI
        private Weather weather;

        // The city name/zip input by the user
        private string city;

        // The complete raw json data pulled from the API
        private string rawJson;

        // Initializes the ExportForm
        // @Weather weather: the weather object containing the displayed weather data
        // @string city: the city name/zip supplied by the user
        // @string rawJson: the compelte json data pulled from the weather API
        public ExportForm(Weather weather, string city, string rawJson)
        {
            InitializeComponent();
            this.weather = weather;
            this.city = city;
            this.rawJson = rawJson;

            // Set the default folder path
            textInputFolderPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WeatherAppData");
        }

        // Allows user to select export the weather data to the file location
        // specified in the textInputFolderPath text box
        private void buttonExport_Click(object sender, EventArgs e)
        {
            string folderPath = textInputFolderPath.Text;
            ExportWeatherData(weather, city, folderPath, rawJson);

            // open the folder in File Explorer
            System.Diagnostics.Process.Start("explorer.exe", folderPath);

            // Close the form
            this.Close();
        }

        // Allows the user to change the location the weather data is 
        // written to
        private void buttonChangeLocation_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // condition checks if the "OK" button was selected in the file explorer
                // when selecting a new folder path. "OK" changes the folder path, but
                // cancelling out of the window leaves it unchanged
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textInputFolderPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        // Method exports the weather data to the desired folder determined in the buttonChangeLocation_Click method
        // @Weather weather: the weather object containing the displayed weather information
        // @string city: the city name/zip supplied by the user
        // @string folder: the folder to export the json weather data do
        // @string rawJson: the complete json data pulled from the weather API
        private void ExportWeatherData(Weather weather, string city, string folder, string rawJson)
        {
            if (weather == null || string.IsNullOrWhiteSpace(weather.LocationName))
            {
                return;
            }

            // Replace any invalid file name characters in the city name to make a valid file path
            string validFileName = string.Join("_", weather.LocationName.Split(System.IO.Path.GetInvalidFileNameChars()));

            // Create a folder for the weather logs
            string folderPath = folder;

            // Ensure the folder exists before trying to add to it
            Directory.CreateDirectory(folderPath);

            // create thename of the file
            string fileName = $"{validFileName}.txt";

            // Creating the entire file path
            string filePath = Path.Combine(folderPath, fileName);

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
