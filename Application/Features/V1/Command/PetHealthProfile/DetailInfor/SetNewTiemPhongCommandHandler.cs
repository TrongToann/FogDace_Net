using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.PetHealthProfile;
using static Contract.Service.PetHealthProfile.Command;
using Domain.Entities;

namespace Application.Features.V1.Command.PetHealthProfile.DetailInfor
{
    public class SetNewTiemPhongCommandHandler : ICommandHandler<SetNewTiemPhong, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SetNewTiemPhongCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Response>> Handle(SetNewTiemPhong request, CancellationToken cancellationToken)
        {
            var petHealthProfile = Result.CheckExist(await _unitOfWork.GetRepository<TiemPhong, Guid>()
                .FindByIdAsync(request.CreateInforDTO.PetHealthProfile_id)).Value;
            _unitOfWork.GetRepository<TiemPhong, Guid>().Add(new TiemPhong
            {
                PetHealthProfile_id = request.CreateInforDTO.PetHealthProfile_id,
                Date = request.CreateInforDTO.Date,
                Note = request.CreateInforDTO.Note,
            });
            return _mapper.Map<Response>(petHealthProfile);
        }
    }
}
