using Bunit;
using BUnitDemoProject.Pages;
using Microsoft.AspNetCore.Components;

namespace BUnitTests.CombinedPartialTests;

public partial class WeatherTests : TestContext
{
}

public class DelayedWeatherService(int forecastsCount) : Weather.IWeatherService
{

    public async Task<List<Weather.WeatherForecast>> GetWeatherForecasts(DateTime date)
    {
        await Task.Delay(1000);
        var forecasts = new List<Weather.WeatherForecast>();
            
        for (int i = 0; i < forecastsCount; i++)
        {
            forecasts.Add(new Weather.WeatherForecast()
            {
                Date = DateOnly.FromDateTime(date.AddDays(i)),
                TemperatureC = 20 + i,
                Summary = "Sunny"
            });
        }

        return forecasts;
    }
}

public class NonDelayedWeatherService(int forecastsCount) : Weather.IWeatherService
{

    public Task<List<Weather.WeatherForecast>> GetWeatherForecasts(DateTime date)
    {
        var forecasts = new List<Weather.WeatherForecast>();
            
        for (int i = 0; i < forecastsCount; i++)
        {
            forecasts.Add(new Weather.WeatherForecast()
            {
                Date = DateOnly.FromDateTime(date.AddDays(i)),
                TemperatureC = 20 + i,
                Summary = "Sunny"
            });
        }

        return Task.FromResult(forecasts);
    }
}