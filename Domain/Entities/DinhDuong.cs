using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("DinhDuong")]
    public class DinhDuong : EntityBase<Guid>
    {
        [ForeignKey(nameof(PetHealthProfile))]
        public Guid PetHealthProfile_id { get; set; }
        public PetHealthProfile PetHealthProfile { get; set; }
        public string Note { get; set; }
    }
}
