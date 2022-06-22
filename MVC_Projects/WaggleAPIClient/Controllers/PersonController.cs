using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WaggleAPIClient.Models;

namespace WaggleAPIClient.Controllers
{
    [Authorize(Roles ="WaggleUser")]
    public class PersonController : Controller
    {
        private readonly HttpClient client=null;
        private string personApiUrl = "";
        public PersonController(HttpClient client, IConfiguration config)
        {
            this.client = client;
            personApiUrl = config.GetValue<string>("AppSettings:PersonApiUrl");
        }
        public  async Task<IActionResult> ListOfPersonsAsync()
        {
            HttpResponseMessage response = await client.GetAsync(personApiUrl);
            string stringData=await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Person> data = JsonSerializer.Deserialize<List<Person>>(stringData, options);
            return View(data);
        }
    }
}
