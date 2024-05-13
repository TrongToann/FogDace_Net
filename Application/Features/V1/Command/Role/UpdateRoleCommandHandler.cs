using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.Factory;
using Contract.Service.Role;
using static Contract.Service.Role.Command;

namespace Application.Features.V1.Command.Role
{
    public class UpdateRoleCommandHandler : ICommandHandler<UpdateRole, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Response>> Handle(UpdateRole request, CancellationToken cancellationToken)
        {
            var role = Result.CheckExist(
                    await _unitOfWork.GetRepository<Domain.Entities.Role, Guid>()
                .FindByIdAsync(request.Role_id)).Value;

            await UpdateRoleValue(request, role);

            RoleFactory.UpdateRolePermission($"{role.Member}_{role.Action}", role.Permission);

            return _mapper.Map<Response>(role);
        }

        private async Task UpdateRoleValue(UpdateRole request, Domain.Entities.Role role)
        {
            _mapper.Map(request.UpdateRoleDTO, role);

            _unitOfWork.GetRepository<Domain.Entities.Role, Guid>()
                .Update(role);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
