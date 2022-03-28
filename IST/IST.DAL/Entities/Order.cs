using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IST.DAL.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public Customer Customer { get; set; }
    }
}
