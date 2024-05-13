using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public interface IApplicationDBContext
    {
        DbSet<Account> Account { get; set; }
        DbSet<Token> Token { get; set; }
        DbSet<TokenUsed> TokenUsed { get; set; }
    }
}
