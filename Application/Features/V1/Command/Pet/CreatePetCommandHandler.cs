using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Domain.Abstraction.Repositories;
using static Contract.Service.Pet.Command;

namespace Application.Features.V1.Command.Pet
{
    public class CreatePetCommandHandler : ICommandHandler<CreatePet>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public CreatePetCommandHandler(IUnitOfWork unitOfWork, IPetRepository petRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(CreatePet request, CancellationToken cancellationToken)
        {
            var pet = _mapper.Map<Domain.Entities.Pet>(request.CreatePetDTO);
            _petRepository.Add(pet);
            await _unitOfWork.SaveChangesAsync(request.CreatePetDTO.Account_id);
            return Result.Success();
        }
    }
}
