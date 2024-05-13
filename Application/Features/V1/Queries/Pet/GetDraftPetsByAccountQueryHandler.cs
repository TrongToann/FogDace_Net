using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.Pet;
using Domain.Abstraction.Repositories;
using static Contract.Service.Pet.Query;

namespace Application.Features.V1.Queries.Pet
{
    public class GetDraftPetsByAccountQueryHandler : IQueryHandler<GetDraftPetsByAccount, ICollection<Response>>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public GetDraftPetsByAccountQueryHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }
        public async Task<Result<ICollection<Response>>> Handle(GetDraftPetsByAccount request, CancellationToken cancellationToken)
        {
            var pets = await _petRepository.GetDraftPetsByAccount(request.Account_id, includeProperties: x => x.PetType);
            return _mapper.Map<List<Response>>(pets);
        }
    }
}
