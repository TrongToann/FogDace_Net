using Domain.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Orders")]
    public class Order : EntityDeleteBase<Guid>
    {
        [Column]
        [Required]
        [ForeignKey(nameof(Account))]
        public Guid Account_id { get; set; }
        public decimal TotalOrder { get; set; }
        public string Payment_Medthod { get; set; }
        public virtual Account Account { get; set; }
        public virtual OrderShipping OrderShipping { get; set; }
        public virtual ICollection<OrderProducts> OrderProducts {  get; set;  }
        public virtual ICollection<OrderStatus> OrderStatus { get; set; }

    }
}
