using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("OrderProducts")]
    public class OrderProducts : EntityBase<Guid>
    {
        [ForeignKey(nameof(Order))]
        public Guid Order_id { get; set; }
        [ForeignKey(nameof(Product))]
        public Guid Product_id { get; set; }
        public int TotalProduct { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
