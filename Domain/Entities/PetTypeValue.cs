using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("PetTypeValue")]
    public class PetTypeValue : EntityBase<Guid>
    {
        [ForeignKey(nameof(PetType))]
        public Guid PetType_id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public int Life_span { get; set; }
        public decimal Weight { get; set; }
        public PetType PetType { get; set; }
    }
}
