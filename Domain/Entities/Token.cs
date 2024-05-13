using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Token")]
    public class Token : EntityBase<Guid>
    {
        [ForeignKey(nameof(Account))]
        public Guid Account_id { get; set; }
        public string RefreshToken { get; set; }
        public string PublicKey { get; set; }
        public ICollection<TokenUsed> TokenUsed { get; set; }
        public Account Account { get; set; }
    }
}
