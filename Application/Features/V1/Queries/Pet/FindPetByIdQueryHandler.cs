using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.Pet;
using Domain.Abstraction.Repositories;
using Domain.Exceptions.Pet;
using static Contract.Service.Pet.Query;

namespace Application.Features.V1.Queries.Pet
{
    public class FindPetByIdQueryHandler : IQueryHandler<FindPetById, Response>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public FindPetByIdQueryHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<Result<Response>> Handle(FindPetById request, CancellationToken cancellationToken)
        {
            var pet = await _petRepository.FindByIdAsync(request.Pet_id, includeProperties: x => x.PetType);
            if (pet is null) throw new PetNotFound(request.Pet_id);
            return _mapper.Map<Response>(pet);
        }
    }
}
