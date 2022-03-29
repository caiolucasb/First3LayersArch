using IST.BLL.DTO;
using IST.DAL.Entities;
using System.Collections.Generic;

namespace IST.BLL.FactoryDTO
{
    public class CustomerFactory
    {
        private readonly OrderFactory _orderFactory;
        public CustomerFactory()
        {
            _orderFactory = new OrderFactory();
        }
        public Customer InboundCustomerToEntity(InboundCustomer inbound)
        {
            var customer = new Customer();
            customer.Name = inbound.Name;
            customer.Email = inbound.Email;
            return customer;
        }

        public OutboundCustomer EntityToOutboundCustomer(Customer entity)
        {
            var outbound = new OutboundCustomer();
            outbound.Id = entity.Id;
            outbound.Name = entity.Name;
            outbound.Email = entity.Email;
            return outbound;
        }

        public OutboundCustomerWithOrders EntityToOutboundCustomerWithOrders(Customer entity)
        {
            var outbound = new OutboundCustomerWithOrders();
            outbound.Id = entity.Id;
            outbound.Name = entity.Name;
            outbound.Email = entity.Email;
            outbound.Orders = _orderFactory.EntitiesToListOfOutboundOrders(entity.Orders);
            return outbound;
        }

        public List<OutboundCustomer> EntitiesToListOfOutboundCustomers(List<Customer> entities)
        {
            var outbound = new List<OutboundCustomer>();
            foreach (var entity in entities)
            {
                outbound.Add(EntityToOutboundCustomer(entity));
            }
            return outbound;
        }
    }
}
