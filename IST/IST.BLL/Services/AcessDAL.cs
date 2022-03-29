using System;
using IST.BLL.DTO;
using IST.DAL.Repository;
using IST.BLL.FactoryDTO;
using System.Collections.Generic;

namespace IST.BLL.Services
{
    public class AcessDAL
    {
        private readonly DbAcess _db;
        private readonly CustomerFactory _customerFactory;
        private readonly OrderFactory _orderFactory;
        private readonly ValidationsBLL _validations;
        public AcessDAL()
        {
            _db = new DbAcess();
            _customerFactory = new CustomerFactory();
            _orderFactory = new OrderFactory();
            _validations = new ValidationsBLL();
        }

        public void CreateACustomerBLL(InboundCustomer inbound)
        {
            try
            {
                if (!_validations.IsValidEmail(inbound.Email))
                    throw new Exception("Email is not valid!");
                if (!_validations.IsValidName(inbound.Name))
                    throw new Exception("Name is not valid!");
                var customer = _customerFactory.InboundCustomerToEntity(inbound);
                _db.AddANewCustomer(customer);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public OutboundCustomerWithOrders GetACustomerBLL(int id)
        {
            try
            {
                if(!_validations.IsAValidId(id))
                    throw new Exception("This Id is not valid!");
                var customer = _db.GetACustomer(id);
                customer.Orders = _db.GetOrdersByCustomerId(id);
                return _customerFactory.EntityToOutboundCustomerWithOrders(customer);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<OutboundCustomer> GetAllCustomersBLL()
        {
            try
            {
                var customersList = _db.GetAllCustomers();
                return _customerFactory.EntitiesToListOfOutboundCustomers(customersList);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void CreateAOrder(InboundOrder inbound)
        {
            try
            {
                if (!_validations.IsAValidId(inbound.CustomerId))
                    throw new Exception("This CustomerId is not valid!");
                var order = _orderFactory.InboundOrderToEntity(inbound);
                _db.AddANewOrder(order);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void UpdateStatus(int orderId, bool status)
        {
            try 
            {
                if (!_validations.IsAValidId(orderId))
                    throw new Exception("This orderId is not valid!");
                _db.UpdateOrderStatus(orderId, status);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
