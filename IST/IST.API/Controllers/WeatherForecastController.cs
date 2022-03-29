using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using IST.BLL.DTO;
using IST.BLL.Services;


namespace IST.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AcessDAL _db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _db = new AcessDAL();
        }

        [HttpGet("/Customer/{id}")]
        public OutboundCustomerWithOrders GetOne(int id)
        {
            return _db.GetACustomerBLL(id);
        }
        [HttpGet("/Customers")]
        public List<OutboundCustomer> GetAll()
        {
            return _db.GetAllCustomersBLL();
        }
        [HttpPost("/Customer")]
        public IActionResult CreateCustomer([FromBody] InboundCustomer customer)
        {
            _db.CreateACustomerBLL(customer);
            return Ok(customer);
        }
        [HttpPost("/Order")]
        public IActionResult CreateOrder([FromBody] InboundOrder order)
        {
            _db.CreateAOrder(order);
            return Ok(order);
        }
    }
}
