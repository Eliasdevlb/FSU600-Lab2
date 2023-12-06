using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _apiKey = "25c90f9a6f62ebef60dcc8f072654e49";
    }

    public async Task<WeatherResult> GetWeatherForCity(string city)
    {
        var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error retrieving weather data");
        }
        var resultJson = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<WeatherResult>(resultJson);
        return  result;
    }
}

public class WeatherResult
{
    [JsonProperty("weather")]
    public WeatherDescription[] Weather { get; set; }

    [JsonProperty("main")]
    public MainWeatherData Main { get; set; }

    public class WeatherDescription
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class MainWeatherData
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
    }
}
