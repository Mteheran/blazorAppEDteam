using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Microsoft.Extensions.Logging;
using static blazorApp.Pages.FetchData;

namespace blazorApp.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private HttpClient Http {get;set;}
        private ILogger<WeatherForecastService> Logger;
        private IToastService ToastService;

        public WeatherForecastService(HttpClient http, ILogger<WeatherForecastService> logger, IToastService toastService)
        {
            Http = http;
            Logger = logger;
            ToastService = toastService;
        }

        public async Task<WeatherForecast[]> GetWeatherForecasts()
        {
            List<WeatherForecast> listResult = new List<WeatherForecast>();
            try
            {
                listResult = (await Http.GetFromJsonAsync<WeatherForecast[]>("https://localhost:5005/weatherforecast")).ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                ToastService.ShowError("Error getting data");
            }

            return listResult.ToArray();
        }
    }

    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetWeatherForecasts();
    }
}