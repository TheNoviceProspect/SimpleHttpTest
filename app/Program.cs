using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherBit.Data;

namespace WeatherBit
{
    class Program
    {
        private static string GetToken(string _tokenFile) {
            if (File.Exists(_tokenFile)) {
                var token = File.ReadAllText(_tokenFile);
                return token;
            } else return string.Empty;
        }

        static void WriteOutput(string _path, string _output)
        {
            using (StreamWriter writer = new StreamWriter(_path, false))
            {
                writer.Write(_output);
            }
        }

        static async Task Main(string[] args)
        {
            string city = "London";

            // Create the HTTP client
            var client = new HttpClient();

            // Set the API key
            //client.DefaultRequestHeaders.Add("x-api-key", GetToken("weather_token.secret"));

            // Build the request URL
            var url = "https://api.weatherbit.io/v2.0/current/";
            var _token = GetToken("weather_token.secret").TrimEnd('\n');
            var query = $"{url}?key={_token}&city={city}";
            string debugQuery = String.Empty;
            if (_token == string.Empty)
            {
                debugQuery = $"{url}?key=**EMPTY**&city={city}";
            }
            else
            {
                debugQuery = $"{url}?key=**REDACTED**&city={city}";
            }
            
            var uri = new Uri(query);
            WriteOutput("query.txt",debugQuery);

            // Send the request
            var response = await client.GetAsync(uri);

            // Check the response status code
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Get the weather data
                string? weatherData = await response.Content.ReadAsStringAsync();
                WriteOutput("return.json", weatherData);
                using FileStream openStream = File.OpenRead("return.json");
                // Parse the weather data

                WeatherData? rawWeather = await JsonSerializer.DeserializeAsync<WeatherData>(openStream);

                // Print the weather data
                Console.WriteLine($"The weather in {rawWeather?.data[0].city_name} is: {rawWeather?.data[0].temp}°C, {rawWeather?.data[0].rh}%");
            }
            else
            {
                // Handle the error
                Console.WriteLine($"Error getting weather data: {response.StatusCode}");
            }
        }
    }

}