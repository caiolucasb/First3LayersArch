using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using IST.DAL.Repository;
using IST.DAL.Entities;

namespace IST.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DbAcess _db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _db = new DbAcess();
        }

        [HttpGet("/Customer/{id}")]
        public Customer GetOne(int id)
        {
            return _db.GetACustomer(id);
        }
        [HttpGet("/Customers")]
        public List<Customer> GetAll()
        {
            return _db.GetAllCustomers();
        }
        [HttpPost("/Customer")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            _db.AddANewCustomer(customer);
            return Ok(customer);
        }
        [HttpPost("/Order")]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            _db.AddANewOrder(order);
            return Ok(order);
        }
    }
}
