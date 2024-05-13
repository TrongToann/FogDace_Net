using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Domain.Abstraction.Repositories;
using static Contract.Service.Pet.Command;

namespace Application.Features.V1.Command.Pet
{
    public class UpdatePetCommandHandler : ICommandHandler<UpdatePet>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPetRepository _petRepository;

        public UpdatePetCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPetRepository petRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _petRepository = petRepository;
        }

        public async Task<Result> Handle(UpdatePet request, CancellationToken cancellationToken)
        {
            var pet = Result.Create(await _petRepository.FindByIdAsync(request.Pet_id)).Value;
            _petRepository.Update(_mapper.Map(request.UpdatePetDTO, pet));
            await _unitOfWork.SaveChangesAsync(request.Account_id);
            return Result.Success();
        }
    }
}
