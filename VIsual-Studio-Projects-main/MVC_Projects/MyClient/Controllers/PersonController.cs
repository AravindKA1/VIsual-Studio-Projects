using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyClient.Models;
using System.Text.Json;

namespace MyClient.Controllers
{
    [Authorize(Roles = "WaggleUser")]
    public class PersonController : Controller
    {
        private readonly HttpClient client = null;
        private string personApiUrl = "";
        public PersonController(HttpClient client, IConfiguration config)
        {
            this.client = client;
            personApiUrl = config.GetValue<string>("AppSettings:PersonApiUrl");
        }
        public async Task<IActionResult> ListOfPersonsAsync()
        {
            HttpResponseMessage response = await client.GetAsync(personApiUrl);
            string stringData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Person> data = JsonSerializer.Deserialize<List<Person>>(stringData, options);

            return View(data);
        }
        [HttpGet]
       
        public async Task<IActionResult> InsertAsync()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertAsync(Person model)
        {
            if (ModelState.IsValid)
            {
                string stringData = JsonSerializer.Serialize(model);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(personApiUrl, contentData);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Person inserted successfully";
                }
                else
                {
                    ViewBag.Message = "Error when calling Web API";
                }
            }
            return View(model);
        }
        [HttpGet]
       
        public async Task<IActionResult> UpdateAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{personApiUrl}/{id}");
            string stringData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Person model = JsonSerializer.Deserialize<Person>(stringData, options);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(Person model)
        {
            if (ModelState.IsValid)
            {
                string stringData = JsonSerializer.Serialize(model);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"{personApiUrl}/{model.PersonID}", contentData);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Person updated successfully";
                }
                else
                {
                    ViewBag.Message = "Error when calling Web API";
                }
            }
            return View(model);
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDeleteAsync(int id)
        {

            HttpResponseMessage response = await client.GetAsync($"{personApiUrl}/{id}");
            string stringData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Person model = JsonSerializer.Deserialize<Person>(stringData, options);
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int personId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{personApiUrl}/{personId}");
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Person Deleted Succesfully";
            }
            else
            {
                TempData["Message"] = "Error while calling Web API";
            }
            return RedirectToAction("ListOfPersons");
      
        }
    }
}