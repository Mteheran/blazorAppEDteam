using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using blazorApp.Services;
using Blazored.Toast;
using blazorApp.Helpers;

namespace blazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Logging.SetMinimumLevel(LogLevel.Debug);

            builder.Services.AddBlazoredToast();

            string ApiUrl = builder.Configuration.GetValue<string>("apiUrl");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(ApiUrl) });
            builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            builder.Services.AddScoped<IJavascriptHelper, JavascriptHelper>();
            
            await builder.Build().RunAsync();
        }
    }
}
