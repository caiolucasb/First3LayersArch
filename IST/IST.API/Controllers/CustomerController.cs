using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using IST.BLL.DTO;
using IST.BLL.Services;
using System;

namespace IST.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AcessDAL _db;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _db = new AcessDAL();
            _logger = logger;
        }

        [HttpGet("/Customer/{id}")]
        public IActionResult GetOne(int id)
        {
            try
            {
                OutboundCustomerWithOrders outbound = _db.GetACustomerBLL(id);
                return Ok(outbound);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error, cannot get the customer");
                return BadRequest(ex);
            }

        }
        [HttpGet("/Customers")]
        public IActionResult GetAll()
        {
            try
            {
                List<OutboundCustomer> constumers = _db.GetAllCustomersBLL();
                return Ok(constumers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error, cannot get the costumer's list");
                return BadRequest(ex);
            }
        }
        [HttpPost("/Customer")]
        public IActionResult CreateCustomer([FromBody] InboundCustomer customer)
        {
            try
            {
                _db.CreateACustomerBLL(customer);
                return Ok(customer);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error, cannot create the customer");
                return BadRequest(ex);
            }
        }
        [HttpPost("/Order")]
        public IActionResult CreateOrder([FromBody] InboundOrder order)
        {
            try
            {
                _db.CreateAOrder(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error, cannot create the customer's order");
                return BadRequest(ex);
            }
        }
        [HttpPatch("/Order/{orderId}/Status/{status}")]
        public IActionResult UpdateOrderStatus(int orderId, bool status)
        {
            try
            {
                _db.UpdateStatus(orderId, status);
                return Ok("The order's status was updated!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em atualizar o status da ordem");
                return BadRequest(ex);
            }
        }
    }
}
