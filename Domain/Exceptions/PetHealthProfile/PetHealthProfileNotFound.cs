namespace Domain.Exceptions.PetHealthProfile
{
    public class PetHealthProfileNotFound : NotFoundException
    {
        public PetHealthProfileNotFound(Guid Pet_id) : 
            base($"PetHealthProfile with Pet id {Pet_id} was not found!")
        {
        }
    }
}
