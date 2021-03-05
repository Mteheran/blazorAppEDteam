using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static blazorApp.Pages.FetchData;

namespace blazorApp.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public HttpClient Http {get;set;}

        public WeatherForecastService(HttpClient http)
        {
            Http = http;
        }

        public async Task<WeatherForecast[]> GetWeatherForecasts()
        {
            return await Http.GetFromJsonAsync<WeatherForecast[]>("https://localhost:5005/weatherforecast");
        }
    }

    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetWeatherForecasts();
    }
}