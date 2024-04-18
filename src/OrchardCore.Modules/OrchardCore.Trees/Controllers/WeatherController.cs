// https://localhost:44300/HallsCreekTreeFarm/weather
// Controllers/WeatherController.cs
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Trees.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrchardCore.Trees.Controllers
{
    [Route("weather")]
    public class WeatherController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string apiKey = "c7ed88cd1ede651e29c58d3b8e3f3f02";

        public WeatherController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet, HttpPost]
        public async Task<IActionResult> Index(string city)
        {
            WeatherResponse weatherResponse = null;

            if (!string.IsNullOrEmpty(city))
            {
                var url = $"http://api.openweathermap.org/data/2.5/weather?q={city},us&appid={apiKey}&units=imperial";
                var client = _clientFactory.CreateClient();
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(content);
                }
                // make sure the city doesnt have a default value
                ViewData["SelectedCity"] = city;
            }

            return View(weatherResponse); 
        }
    }
}

// looking for small chnage for git


