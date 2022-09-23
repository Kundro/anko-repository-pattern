using System.CodeDom;
using Customer.Datalayer.BusinessEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Datalayer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static List<Customers> customers = new List<Customers>
        {
            new Customers
            {
                CustomerId = 1,
                FirstName = "TestName",
                LastName = "TestLastName",
                Addresses = new List<Addresses>(),
                Email = "test@mail.ru",
                Notes = "TestNote",
                PhoneNumber = "+12341234567890",
                TotalPurchasesAmount = 1
            },
            new Customers
            {
                CustomerId = 2,
                FirstName = "TestName2",
                LastName = "TestLastName2",
                Addresses = new List<Addresses>(),
                Email = "test2@mail.ru",
                Notes = "TestNote2",
                PhoneNumber = "+12341234567890",
                TotalPurchasesAmount = 2
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Customers>>> Get()
        {
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customers>>> AddCustomer(Customers customer)
        {
            customers.Add(customer);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> Get(int id)
        {
            var customer = customers.Find(c => c.CustomerId == id);
            if (customer == null) return BadRequest("Customer not found");
            return Ok(customer);
        }

        [HttpPut]
        public async Task<ActionResult<List<Customers>>> UpdateCustomer(Customers customer)
        {
            var newCustomer = customers.Find(c => c.CustomerId == customer.CustomerId);
            if (newCustomer == null) return BadRequest("Customer not found");

            newCustomer.FirstName = customer.FirstName;
            newCustomer.LastName = customer.LastName;
            newCustomer.Email = customer.Email;
            newCustomer.PhoneNumber = customer.PhoneNumber;
            newCustomer.Notes = customer.PhoneNumber;
            newCustomer.TotalPurchasesAmount = customer.TotalPurchasesAmount;
            newCustomer.Addresses = customer.Addresses;

            return Ok(customers);
        }
    }
}
