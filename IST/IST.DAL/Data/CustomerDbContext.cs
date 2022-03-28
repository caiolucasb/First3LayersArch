using Microsoft.EntityFrameworkCore;
using IST.DAL.Entities;

namespace IST.DAL.Data
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CustomerApp;Data Source=DESKTOP-CKBOR6V");
        }
    }
}
