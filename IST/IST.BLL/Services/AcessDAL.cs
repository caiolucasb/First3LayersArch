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
        public AcessDAL()
        {
            _db = new DbAcess();
            _customerFactory = new CustomerFactory();
            _orderFactory = new OrderFactory();
        }

        public void CreateACustomerBLL(InboundCustomer inbound)
        {
            var customer = _customerFactory.InboundCustomerToEntity(inbound);
            _db.AddANewCustomer(customer);
        }

        public OutboundCustomerWithOrders GetACustomerBLL(int id)
        {
            var customer = _db.GetACustomer(id);
            customer.Orders = _db.GetOrdersByCustomerId(id);
            return _customerFactory.EntityToOutboundCustomerWithOrders(customer);
        }

        public List<OutboundCustomer> GetAllCustomersBLL()
        {
            var customersList = _db.GetAllCustomers();
            return _customerFactory.EntitiesToListOfOutboundCustomers(customersList);
        }

        public void CreateAOrder(InboundOrder inbound)
        {
            var order = _orderFactory.InboundOrderToEntity(inbound);
            _db.AddANewOrder(order);
        }
    }
}
