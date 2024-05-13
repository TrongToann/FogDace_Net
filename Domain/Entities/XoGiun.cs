using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("XoGiun")]
    public class XoGiun : EntityBase<Guid>
    {
        [ForeignKey(nameof(PetHealthProfile))]
        public Guid PetHealthProfile_id { get; set; }
        public PetHealthProfile PetHealthProfile { get; set; }
        public DateTime Date { get; set; }
    }
}
