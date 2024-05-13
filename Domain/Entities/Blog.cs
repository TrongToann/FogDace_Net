using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Blog")]
    public class Blog : EntityAuditBase<Guid>
    {
        [ForeignKey("Account")]
        public Guid Account_id { get; set; }
        public string Title { get; set; }
        public string Image {  get; set; }
        public string Description { get; set; } 
        public int Views {  get; set; } = 0;
        public Account Account { get; set; }
    }
}
