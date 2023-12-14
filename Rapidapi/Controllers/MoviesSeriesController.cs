using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rapidapi.Models;

namespace Rapidapi.Controllers
{
    public class MoviesSeriesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"),
                Headers =
    {
        { "X-RapidAPI-Key", "017e332112msh23716e748341798p191d8bjsn2ef5f5a5a366" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<SeriesViewModel>>(body);
                return View(values);
            }
            
        }
    }
}
