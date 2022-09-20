using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Datalayer.WebApi.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public readonly IRepository<Customers> _customerRepository;

        public CustomersController(IRepository<Customers> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: CustomersController
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<Customers>> GetAll()
        {
            var customers = _customerRepository.GetAll();

            if (customers.Count == 0)
            {
                return NotFound("NOT FOUND");
            }
            return Ok(_customerRepository.GetAll());
        }

        // POST: CustomersController
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateCustomer([FromBody] Customers customer)
        {
            _customerRepository.Create(customer);
            return Ok();
        }
    }
}
