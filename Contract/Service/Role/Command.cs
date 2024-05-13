using Contract.Abstraction.Message;
using Contract.DTOs.RoleDTO;
using Contract.Service.Auth;

namespace Contract.Service.Role
{
    public static class Command
    {
        public record CreateRole(CreateRoleDTO CreateRoleDTO) : ICommand { }
        public record UpdateRole(Guid Role_id, UpdateRoleDTO UpdateRoleDTO) : ICommand<Response> { }
    }
}
