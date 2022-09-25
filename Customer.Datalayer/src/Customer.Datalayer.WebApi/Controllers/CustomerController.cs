using Customer.Datalayer.BusinessEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Datalayer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext dbContext;

        public CustomerController(CustomerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customers>>> Get()
        {
            return Ok(await dbContext.Customers.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Customers>>> AddCustomer(Customers customer)
        {
            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();
            return Ok(await dbContext.Customers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> Get(int id)
        {
            var customer = await dbContext.Customers.FindAsync(id);
            if (customer == null) return BadRequest("Customer not found");
            return Ok(customer);
        }

        [HttpPut]
        public async Task<ActionResult<List<Customers>>> UpdateCustomer(Customers customer)
        {
            var dbCustomer = await dbContext.Customers.FindAsync(customer.CustomerId);
            if (dbCustomer == null) return BadRequest("Customer not found");

            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.Email = customer.Email;
            dbCustomer.PhoneNumber = customer.PhoneNumber;
            dbCustomer.Notes = customer.PhoneNumber;
            dbCustomer.TotalPurchasesAmount = customer.TotalPurchasesAmount;
            dbCustomer.Addresses = customer.Addresses;

            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Customers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customers>>> Delete(int id)
        {
            var customer = await dbContext.Customers.FindAsync(id);
            if (customer == null) return BadRequest("Customer not found");
            dbContext.Customers.Remove(customer);

            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Customers.ToListAsync());
        }
    }
}
