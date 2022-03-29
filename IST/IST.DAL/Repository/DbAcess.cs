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
            try
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            } 
        }

        public void AddANewCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                List<Customer> customers = _context.Customers.ToList();
                if(customers == null)
                    throw new Exception("Cannot find any customers in database");
                return customers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Customer GetACustomer(int id)
        {
            try
            {
                Customer customer = _context.Customers.SingleOrDefault(x => x.Id == id);
                if (customer == null)
                    throw new Exception("Cannot find this id in database");
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Order> GetOrdersByCustomerId(int id)
        {
            try
            {
                List<Order> orders = _context.Orders.Where(order => order.Customer.Id == id).ToList();
                if (orders == null)
                    throw new Exception("Cannot find this CustomerId in database");
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                Order order = _context.Orders.SingleOrDefault(x => x.Id == id);
                if (order == null)
                    throw new Exception("Cannot find this orderId in database");
                return order;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateOrderStatus(int id, bool status)
        {
            try
            {
                var order = GetOrderById(id);
                order.Status = status ? "Approved" : "Denied";
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    } 
}
