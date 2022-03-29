using System;
using System.Collections.Generic;
using IST.BLL.DTO;
using IST.BLL.FactoryDTO;
using IST.DAL.Entities;
using Xunit;

namespace IST.BLL.TEST.FactoryDTO
{
    public class OrderFactoryTest
    {
        private OrderFactory _factory;
        public OrderFactoryTest()
        {
            _factory = new OrderFactory();
        }

        [Fact]
        public void ShouldTurnEntityToOutboundOrder()
        {
            var order = new Order();
            order.Id = 5;
            order.Price = 10;
            var outbound = _factory.EntityToOutboundOrder(order);
            Assert.IsType<OutboundOrder>(outbound);
            Assert.Equal(order.Id, outbound.Id);
            Assert.Equal(order.Price, outbound.Price);
        }

        [Fact]
        public void ShouldTurnInboundOrderToEntity()
        {
            var inbound = new InboundOrder();
            inbound.CustomerId = 5;
            inbound.Price = 10;
            var entity = _factory.InboundOrderToEntity(inbound);
            Assert.IsType<Order>(entity);
            Assert.Equal(inbound.CustomerId, entity.CustomerId);
            Assert.Equal(inbound.Price, entity.Price);
        }

        [Fact]
        public void ShouldTurnEntitiesToListOfOutboundOrders()
        {
            var entities = new List<Order>();
            var order = new Order { Id = 5, Price = 10 };
            entities.Add(order);
            var outbound = _factory.EntitiesToListOfOutboundOrders(entities);
            Assert.IsType<List<OutboundOrder>>(outbound);
            Assert.Equal(outbound.Count, entities.Count);
        }
    }
}
