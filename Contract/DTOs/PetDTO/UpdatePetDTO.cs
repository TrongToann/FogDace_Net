
namespace Contract.DTOs.PetDTO
{
    public class UpdatePetDTO
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
    }
}
