using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Model;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _context;
        public CustomerController(CustomerDbContext context)
        {
            _context = context;
        }
        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        [HttpGet("{id}")]
        public Customer GetCustomerById(int id)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == id);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cus = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cus == null)
            {
                return NotFound("Customer with Id " + id + " does not exist");
            }
            else
            {
                _context.Customers.Remove(cus);
                _context.SaveChanges();
                return Ok("Customer with Id " + id + " deleted successfully");
            }
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Created("api/customer" + customer.Id, customer);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer customer)
        {
            var cus = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cus == null)
            {
                return NotFound("Customer with Id " + id + " does not exist");
            }
            if (customer.FirstName != null)
            {
                cus.FirstName = customer.FirstName;

            }
            if (customer.LastName != null)
            {
                cus.LastName = customer.LastName;

            }
            if (customer.Address != null)
            {
                cus.Address = customer.Address;
            }
            if (customer.Email != null)
            {

                cus.Email = customer.Email;
            }
            _context.Update(cus);
            _context.SaveChanges();
            return Ok("Customer with Id " + id + " Updated Successfully");
        }
    }
}
