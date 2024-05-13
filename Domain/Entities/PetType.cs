using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("PetType")]
    public class PetType : EntityBase<Guid>
    {
        public string Type {  get; set; }
        public string Image { get; set; }
    }
}
