using Contract.Abstraction.Message;
using Contract.DTOs.Auth;

namespace Contract.Service.Auth
{
    public static class Command
    {
        public record Login(LoginDTO LoginDTO) : ICommand<Response> { }
        public record Register(RegisterDTO RegisterDTO) : ICommand<BaseResponse> { }
        public record Logout(Guid Account_id) : ICommand<BaseResponse> { }
    }
}
