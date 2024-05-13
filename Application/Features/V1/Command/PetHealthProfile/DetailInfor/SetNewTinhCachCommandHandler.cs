using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.PetHealthProfile;
using Domain.Entities;
using static Contract.Service.PetHealthProfile.Command;

namespace Application.Features.V1.Command.PetHealthProfile.DetailInfor
{
    public class SetNewTinhCachCommandHandler : ICommandHandler<SetNewTinhCach, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SetNewTinhCachCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<Response>> Handle(SetNewTinhCach request, CancellationToken cancellationToken)
        {
            var petHealthProfile = Result.CheckExist(await _unitOfWork.GetRepository<TinhCach, Guid>()
                .FindByIdAsync(request.CreateInforDTO.PetHealthProfile_id)).Value;
            _unitOfWork.GetRepository<TinhCach, Guid>().Add(new TinhCach
            {
                PetHealthProfile_id = request.CreateInforDTO.PetHealthProfile_id,
                Date = request.CreateInforDTO.Date,
                Note = request.CreateInforDTO.Note,
            });
            return _mapper.Map<Response>(petHealthProfile);
        }
    }
}
