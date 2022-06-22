using Microsoft.AspNetCore.Mvc;
using WaggleAPI.Models;
using WaggleAPI.Repositories;

namespace WaggleAPI.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository personRepository = null;
        public PersonController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        [HttpGet]
        public List<Person> Get()
        {
            return personRepository.SelectAll();
        }
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return personRepository.SelectByID(id);
        }
        [HttpPost]
        public void Post([FromBody] Person per)
        {
            if (ModelState.IsValid)
            {
                personRepository.Insert(per);
            }
        }
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Person per)
        {
            if (ModelState.IsValid)
            {
                personRepository.Update(per);
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            personRepository.Delete(id);
        }
    }
}