using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Cart")]
    public class Cart : EntityBase<Guid>
    {
        [ForeignKey(nameof(Account))]
        public Guid Account_id { get; set; }
        public int Count_Product { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
