using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rapidapi.Models;

namespace Rapidapi.Controllers
{
    public class SearchLocationController : Controller
    {
        public async Task<IActionResult> Index(string city)
        {
            if(!string.IsNullOrEmpty(city))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={city}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "017e332112msh23716e748341798p191d8bjsn2ef5f5a5a366" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values=JsonConvert.DeserializeObject<List<SearchLocationViewModel>> (body);
                    return View(values.ToList());
                }
               
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name=istanbul&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "017e332112msh23716e748341798p191d8bjsn2ef5f5a5a366" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<SearchLocationViewModel>>(body);
                    return View(values.ToList());
                }
            }

        }
            
           
    }
}
