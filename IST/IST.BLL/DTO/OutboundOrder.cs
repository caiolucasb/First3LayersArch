using System;

namespace IST.BLL.DTO
{
    public class OutboundOrder
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
