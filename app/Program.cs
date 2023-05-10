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

        static async Task Main(string[] args)
        {
            string city = "Hamburg";
            string country = "DE";

            // Create the HTTP client
            var client = new HttpClient();

            var url = "https://api.weatherbit.io/v2.0/current/";
            var _token = GetToken("weather_token.secret").TrimEnd('\n');
            var query = $"{url}?key={_token}&city={city}&country={country}";
            var uri = new Uri(query);

            // Send the request
            var response = await client.GetAsync(uri);

            // Check the response status code
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Get the weather data
                string? weatherData = await response.Content.ReadAsStringAsync();
                Rootobject? rawWeather = JsonSerializer.Deserialize<Rootobject>(weatherData);

                // Print the weather data
                Console.WriteLine($"The weather in {rawWeather?.data[0].city_name} is: {rawWeather?.data[0].temp}°C, {rawWeather?.data[0].rh}%");
                Console.WriteLine($"The conditions are: {rawWeather?.data[0].weather.description}");
            }
            else
            {
                Console.WriteLine($"Error getting weather data: {response.StatusCode}");
            }
        }
    }

}