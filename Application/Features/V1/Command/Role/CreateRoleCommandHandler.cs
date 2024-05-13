using Application.Data;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.Factory;
using Domain.Exceptions.Role;
using static Contract.Service.Role.Command;

namespace Application.Features.V1.Command.Role
{
    public class CreateRoleCommandHandler : ICommandHandler<CreateRole>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateRole request, CancellationToken cancellationToken)
        {
            var lastRole = await GetLastRoleValue();

            var role = await CreateRole(request, lastRole);

            RoleFactory.RegisterRoleType($"{role.Member}_{role.Action}", role.Permission);

            return Result.Success();
        }

        private async Task<Domain.Entities.Role> GetLastRoleValue()
        {
            IEnumerable<Domain.Entities.Role> roles = 
                await _unitOfWork.GetRepository<Domain.Entities.Role, Guid>().GetAllAsync();
            if (!roles.Any()) throw new RoleNotFound();
            return roles.LastOrDefault() ?? null;
        }

        private async Task<Domain.Entities.Role> CreateRole(CreateRole request, Domain.Entities.Role lastRole)
        {
            var role = new Domain.Entities.Role
            {
                Member = request.CreateRoleDTO.Member,
                Value = lastRole.Value * 2,
                Permission = lastRole.Permission + 1,
                Action = request.CreateRoleDTO.Action,
            };
            _unitOfWork.GetRepository<Domain.Entities.Role, Guid>().Add(role);

            await _unitOfWork.SaveChangesAsync();

            return role;
        }
    }
}
