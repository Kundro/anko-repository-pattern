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
        [HttpGet]
        public async Task<ActionResult<List<Customers>>> Get()
        {
            var customers = new List<Customers>
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
                }
            };
            return Ok(customers);
        }
    }
}
