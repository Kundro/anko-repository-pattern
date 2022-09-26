using Customer.Datalayer.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace Customer.Datalayer.EFRepositories
{
    public class CustomerDbContext : DbContext

    {
        public CustomerDbContext()
        {
            // Database.EnsureCreated();
        }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KUNDRO\SQLEXPRESS;Database=redbull2;Trusted_Connection=True;");
        }

        public DbSet<Customers> Customers { get; set; } = null;
        public DbSet<Addresses> Addresses { get; set; } = null;
    }
}
