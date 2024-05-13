using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.PetHealthProfile;
using Domain.Entities;
using static Contract.Service.PetHealthProfile.Command;

namespace Application.Features.V1.Command.PetHealthProfile.DetailInfor
{
    public class SetNewXoGiunCommandHandler : ICommandHandler<SetNewXoGiun, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SetNewXoGiunCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<Response>> Handle(SetNewXoGiun request, CancellationToken cancellationToken)
        {
            var petHealthProfile = Result.CheckExist(await _unitOfWork.GetRepository<XoGiun, Guid>()
                .FindByIdAsync(request.CreateInforDTO.PetHealthProfile_id)).Value;
            _unitOfWork.GetRepository<XoGiun, Guid>().Add(new XoGiun
            {
                PetHealthProfile_id = request.CreateInforDTO.PetHealthProfile_id,
                Date = request.CreateInforDTO.Date,
            });
            return _mapper.Map<Response>(petHealthProfile);
        }
    }
}
