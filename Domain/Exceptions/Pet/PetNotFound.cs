namespace Domain.Exceptions.Pet
{
    public class PetNotFound : NotFoundException
    {
        public PetNotFound(Guid Pet_id) :
            base($"Pet with id {Pet_id} was not found!")
        {
        }
    }
}
