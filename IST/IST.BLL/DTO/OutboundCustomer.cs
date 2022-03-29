using System.Collections.Generic;

namespace IST.BLL.DTO
{
    public class OutboundCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class OutboundCustomerWithOrders : OutboundCustomer
    {
        public List<OutboundOrder> Orders { get; set; }
    }
}
