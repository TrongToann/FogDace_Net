using Domain.Entities;

namespace Domain.Abstraction.Repositories
{
    public interface IPetTypeRepository : IGenericRepository<PetType, Guid>
    {
    }
}
