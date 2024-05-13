using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Role")]
    public class Role : EntityBase<Guid>
    {
        public string Member { get; set; } 
        public int Value { get; set; }
        public int Permission { get; set; }
        public string Action { get; set; }
    }
}
