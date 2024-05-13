using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Content")]
    public class Content : EntityBase<Guid>
    {
        [ForeignKey(nameof(Blog))]
        public Guid Blog_id { get; set; }
        public Blog Blog { get; set; }
        public string Title {  get; set; }
        public string Script {  get; set; }
        public string Image { get; set; }
    }
}
