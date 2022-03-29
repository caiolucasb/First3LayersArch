using System.Collections.Generic;
using IST.BLL.DTO;
using IST.BLL.FactoryDTO;
using IST.DAL.Entities;
using Xunit;

namespace IST.BLL.TEST.FactoryDTO
{
    public class CustomerFactoryTest
    {
        private CustomerFactory _factory;
        public CustomerFactoryTest()
        {
            _factory = new CustomerFactory();
        }

        [Fact]
        public void ShouldTurnEntityToOutboundCustomer()
        {
            var customer = new Customer();
            customer.Id = 5;
            customer.Email = "caio@gmail.com";
            var outbound = _factory.EntityToOutboundCustomer(customer);
            Assert.IsType<OutboundCustomer>(outbound);
            Assert.Equal(customer.Id, outbound.Id);
            Assert.Equal(customer.Email, outbound.Email);
        }

        [Fact]
        public void ShouldTurnInboundCustomerToEntity()
        {
            var inbound = new InboundCustomer();
            inbound.Name = "Caio Lucas";
            inbound.Email = "caio@gmail.com";
            var entity = _factory.InboundCustomerToEntity(inbound);
            Assert.IsType<Customer>(entity);
            Assert.Equal(inbound.Name, entity.Name);
            Assert.Equal(inbound.Email, entity.Email);
        }

        [Fact]
        public void ShouldTurnEntityToOutboundCustomersWithOrders()
        {
            var entity = new Customer();
            entity.Id = 5;
            entity.Email = "caio@gmail.com";
            var outbound = _factory.EntityToOutboundCustomerWithOrders(entity);
            Assert.IsType<OutboundCustomerWithOrders>(outbound);
            Assert.Equal(entity.Email, outbound.Email);
            Assert.Equal(entity.Id, outbound.Id);
        }

        [Fact]
        public void ShouldTurnEntitiesToListOfOutboundCustomers()
        {
            var entities = new List<Customer>();
            var customer = new Customer { Name = "Caio", Id = 10 };
            entities.Add(customer);
            var outbound = _factory.EntitiesToListOfOutboundCustomers(entities);
            Assert.IsType<List<OutboundCustomer>>(outbound);
            Assert.Equal(entities.Count, outbound.Count);
        }
    }
}
