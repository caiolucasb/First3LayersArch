using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IST.BLL.DTO;
using IST.BLL.Services;

namespace IST.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AcessDAL _db;

        public CustomerController()
        {
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
        [HttpPatch("/Order/{orderId}/Status/{status}")]
        public IActionResult UpdateOrderStatus(int orderId, bool status)
        {
            _db.UpdateStatus(orderId, status);
            return Ok("The order's status was updated!");
        }
    }
}
