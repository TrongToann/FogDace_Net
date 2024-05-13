using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Domain.Abstraction.Repositories;
using Domain.Entities;
using Domain.Exceptions.Common;
using static Contract.Service.PetType.Command;

namespace Application.Features.V1.Command.PetType
{
    public class CreatePetTypeCommandHandler : ICommandHandler<CreatePetType>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPetTypeRepository _petTypeRepository;
        private readonly IPetTypeValueRepository _petTypeValueRepository;

        public CreatePetTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, 
            IPetTypeRepository petTypeRepository, IPetTypeValueRepository petTypeValueRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _petTypeRepository = petTypeRepository;
            _petTypeValueRepository = petTypeValueRepository;
        }

        public async Task<Result> Handle(CreatePetType request, CancellationToken cancellationToken)
        {
            var petType = _mapper.Map<Domain.Entities.PetType>(request.CreatePetTypeDTO);
            _petTypeRepository.Add(petType);
            var affectedRecord = await _unitOfWork.SaveChangesAsync();
            if (affectedRecord < 1) throw new InternalServerError();
            await InsertPetTypeValue(request, petType.Id);
            return Result.Success();
        }

        private async Task InsertPetTypeValue(CreatePetType request, Guid petType_id)
        {
            foreach (var value in request.CreatePetTypeDTO.inputPetTypeValues)
            {
                _petTypeValueRepository.Add(new PetTypeValue
                {
                    PetType_id = petType_id,
                    Name = value.Name,
                    Image = value.Image,
                    Description = value.Description,
                    Origin = value.Origin,
                    Life_span = value.Life_span,
                    Weight = value.Weight,
                });
            }
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
