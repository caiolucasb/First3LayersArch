using System;
using IST.BLL.DTO;
using IST.DAL.Entities;
using System.Collections.Generic;

namespace IST.BLL.FactoryDTO
{
    public class OrderFactory
    {
        public OutboundOrder EntityToOutboundOrder(Order entity)
        {
            var outbound = new OutboundOrder();
            outbound.Id = entity.Id;
            outbound.Price = entity.Price;
            outbound.CreatedAt = entity.CreatedAt;
            outbound.Status = entity.Status;
            return outbound;
        }

        public Order InboundOrderToEntity(InboundOrder inbound)
        {
            var order = new Order();
            order.Price = inbound.Price;
            order.CreatedAt = DateTime.Now;
            order.Status = "Pending";
            order.CustomerId = inbound.CustomerId;
            return order;
        }

        public List<OutboundOrder> EntitiesToListOfOutboundOrders(ICollection<Order> entities)
        {
            var outbound = new List<OutboundOrder>();
            if (entities != null)
                foreach (var entity in entities)
                {
                    outbound.Add(EntityToOutboundOrder(entity));
                }
            return outbound;
        }
    }
}
