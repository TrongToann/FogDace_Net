using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Pet")]
    public class Pet : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        [ForeignKey(nameof(Account))]
        public Guid Account_id { get; set; }
        [ForeignKey(nameof(PetType))]
        public Guid PetType_id { get; set; }
        public string Description { get; set; }
        public int Is_trading { get; set; } = 0;
        
        public Account Account { get; set; }
        public PetType PetType { get; set; }
    }
}
