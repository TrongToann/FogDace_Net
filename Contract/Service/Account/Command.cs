using Contract.Abstraction.Message;
using Contract.DTOs.AccountDTO;

namespace Contract.Service.Account
{
    public static class Command
    {
        public record CreateAccount(CreateAccountDTO CreateAccountDTO) : ICommand { }
    }
}
