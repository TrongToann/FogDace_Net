using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.PetHealthProfile;
using static Contract.Service.PetHealthProfile.Command;

namespace Application.Features.V1.Command.PetHealthProfile
{
    public class UpdatePetHealthProfileCommandHandler : ICommandHandler<UpdatePetHealthProfile, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePetHealthProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Response>> Handle(UpdatePetHealthProfile request, CancellationToken cancellationToken)
        {
            var petHealthProfile = Result.Create(await _unitOfWork.GetRepository<Domain.Entities.PetHealthProfile, Guid>()
                .FindByIdAsync(request.PetHealthProfile_id)).Value;
            _mapper.Map(request.UpdatePetHealthProfileDTO, petHealthProfile);
            _unitOfWork.GetRepository<Domain.Entities.PetHealthProfile, Guid>().Update(petHealthProfile);
            await _unitOfWork.SaveChangesAsync(request.Account_id);
            return _mapper.Map<Response>(petHealthProfile);
        }
    }
}
