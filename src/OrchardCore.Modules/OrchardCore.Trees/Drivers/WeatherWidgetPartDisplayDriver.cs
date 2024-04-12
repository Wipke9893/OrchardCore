using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Trees.Models;
using OrchardCore.Trees.ViewModels;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;

namespace OrchardCore.Trees.Drivers;
public class WeatherWidgetPartDisplayDriver : ContentPartDisplayDriver<WeatherWidgetPart>
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string _apiKey = "c7ed88cd1ede651e29c58d3b8e3f3f02";

    public WeatherWidgetPartDisplayDriver(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _clientFactory = clientFactory;
        _httpContextAccessor = httpContextAccessor;
    }

    public override async Task<IDisplayResult> DisplayAsync(WeatherWidgetPart part, BuildPartDisplayContext context)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        string city = httpContext.Request.Query["city"];

        if (string.IsNullOrEmpty(city))
        {
            city = "New York"; // Default city
        }
        WeatherResponse weatherResponse = null;
        var url = $"http://api.openweathermap.org/data/2.5/weather?q={city},us&appid={_apiKey}&units=imperial";
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(content);
            /* weatherResponse = await response.Content.ReadFromJsonAsync<WeatherResponse>();*/
        }

        // List of Cities to choose from
        var availableCities = new List<string> { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix" };

        return Initialize<WeatherWidgetPartViewModel>("WeatherWidgetPart", model =>
        {
            model.WeatherResponse = weatherResponse;
            model.City = city;
            model.AvailableCities = availableCities; // Set the list of cities
        });
    }
}


// Drivers/WeatherWidgetPartDisplayDriver.cs
