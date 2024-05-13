using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.PetHealthProfile;
using Domain.Exceptions.PetHealthProfile;
using static Contract.Service.PetHealthProfile.Query;

namespace Application.Features.V1.Queries.PetHealthProfile
{
    public class FindPetHealthByPetIdQueryHandler : IQueryHandler<FindPetHealthByPetId, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FindPetHealthByPetIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Response>> Handle(FindPetHealthByPetId request, CancellationToken cancellationToken)
        {
            var petHealth = await _unitOfWork.GetRepository<Domain.Entities.PetHealthProfile, Guid>()
                .FindSingleAsync(x => x.Pet_id == request.Pet_id,
                includeProperties: [x => x.DinhDuong, x => x.TinhCach, x => x.TinhTrangSK, x => x.TiemPhong]);
            if (petHealth is null) throw new PetHealthProfileNotFound(request.Pet_id);
            return _mapper.Map<Response>(petHealth);
        }
    }
}
