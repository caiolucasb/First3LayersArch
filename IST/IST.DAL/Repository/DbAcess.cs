using System;
using System.Linq;
using System.Collections.Generic;
using IST.DAL.Data;
using IST.DAL.Entities;


namespace IST.DAL.Repository
{
    public class DbAcess
    {
        private readonly CustomerDbContext _context;
        public DbAcess()
        {
            _context = new CustomerDbContext();
        }

        public void AddANewOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void AddANewCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetACustomer(int id)
        {
            return _context.Customers.SingleOrDefault(x => x.Id == id);
        }
    } 
}
