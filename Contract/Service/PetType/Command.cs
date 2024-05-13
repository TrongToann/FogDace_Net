using Contract.Abstraction.Message;
using Contract.DTOs.PetTypeDTO;

namespace Contract.Service.PetType
{
    public static class Command
    {
        public record CreatePetType(CreatePetTypeDTO CreatePetTypeDTO) : ICommand { }
    }
}
