using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using IST.DAL.Entities;
using IST.DAL.AppSettings;
using System;

namespace IST.DAL.Data
{
    public class CustomerDbContext : DbContext
    {
        readonly ConnectionString _settings;
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public CustomerDbContext(IOptions<ConnectionString> settings)
        {
            _settings = settings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.MsSqlConnectionString);
        }
    }
}
