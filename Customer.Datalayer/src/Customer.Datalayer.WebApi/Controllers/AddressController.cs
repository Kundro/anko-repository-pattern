using Customer.Datalayer.BusinessEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Datalayer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly CustomerDbContext dbContext;

        public AddressController(CustomerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Addresses>>> Get()
        {
            return Ok(await dbContext.Addresses.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Addresses>>> AddCustomer(Addresses address)
        {
            dbContext.Addresses.Add(address);
            await dbContext.SaveChangesAsync();
            return Ok(await dbContext.Addresses.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Addresses>> Get(int id)
        {
            var address = await dbContext.Addresses.FindAsync(id);
            if (address == null) return BadRequest("Address not found");
            return Ok(address);
        }

        [HttpPut]
        public async Task<ActionResult<List<Addresses>>> UpdateCustomer(Addresses address)
        {
            var dbAddress = await dbContext.Addresses.FindAsync(address.AddressId);
            if (dbAddress == null) return BadRequest("Customer not found");

            dbAddress.CustomerId = address.CustomerId;
            dbAddress.AddressLine = address.AddressLine;
            dbAddress.AddressLine2 = address.AddressLine2;
            dbAddress.AddressType = address.AddressType;
            dbAddress.City = address.City;
            dbAddress.PostalCode = address.PostalCode;
            dbAddress.StateName = address.StateName;
            dbAddress.Country = address.Country;

            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Addresses.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Addresses>>> Delete(int id)
        {
            var address = await dbContext.Addresses.FindAsync(id);
            if (address == null) return BadRequest("Address not found");
            dbContext.Addresses.Remove(address);

            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Addresses.ToListAsync());
        }
    }
}
