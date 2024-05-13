using Contract.Abstraction.Message;
using Contract.DTOs.PetDTO;

namespace Contract.Service.Pet
{
    public static class Command
    {
        public record CreatePet(CreatePetDTO CreatePetDTO) : ICommand { }
        public record UpdatePet(Guid Pet_id,Guid Account_id, UpdatePetDTO UpdatePetDTO) : ICommand { }
    }
}
