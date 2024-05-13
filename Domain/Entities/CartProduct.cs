using Domain.Abstraction;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("CartProducts")]
    public class CartProduct : EntityBase<Guid>
    {
        [ForeignKey(nameof(Cart))]
        public Guid Cart_id { get; set; }
        [ForeignKey(nameof(Product))]
        public Guid Product_id { get; set; }
        public int Total { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
