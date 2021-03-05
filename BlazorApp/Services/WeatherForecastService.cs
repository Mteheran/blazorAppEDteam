using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static blazorApp.Pages.FetchData;

namespace blazorApp.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private HttpClient Http {get;set;}
        private ILogger<WeatherForecastService> Logger;
        private IToastService ToastService;
        private IConfiguration Config;
        private string ApiUrl;

        public WeatherForecastService(HttpClient http, ILogger<WeatherForecastService> logger, IToastService toastService, IConfiguration config)
        {
            Http = http;
            Logger = logger;
            ToastService = toastService;
            Config = config;
            ApiUrl = Config.GetValue<string>("apiUrl");
        }

        public async Task<WeatherForecast[]> GetWeatherForecasts()
        {
            List<WeatherForecast> listResult = new List<WeatherForecast>();
            try
            {
                listResult = (await Http.GetFromJsonAsync<WeatherForecast[]>($"weatherforecast")).ToList();
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