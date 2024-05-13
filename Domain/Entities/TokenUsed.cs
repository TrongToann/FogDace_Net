using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TokenUsed")]
    public class TokenUsed : EntityBase<Guid>
    {
        [ForeignKey(nameof(Token))]
        public Guid TokenId { get; set; }
        public string TokenValue { get; set; }
        public Token Token { get; set; }
    }
}
