using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Product")]
    public class Product : EntityStatusBase<Guid>
    {
        public required string Name { get; set; }
        public required string Image {  get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Rating { get; set; }
        public int Sold_Quantity { get; set; }
    }
}
