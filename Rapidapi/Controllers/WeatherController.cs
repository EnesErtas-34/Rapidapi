using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rapidapi.Models;

namespace Rapidapi.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://yahoo-weather5.p.rapidapi.com/weather?location=ankara&format=json&u=c"),
                Headers =
    {
        { "X-RapidAPI-Key", "017e332112msh23716e748341798p191d8bjsn2ef5f5a5a366" },
        { "X-RapidAPI-Host", "yahoo-weather5.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel>(body);
                return View(values);
            }
           
        }
    }
}
