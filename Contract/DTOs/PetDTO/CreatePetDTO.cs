
namespace Contract.DTOs.PetDTO
{
    public class CreatePetDTO : IPetDTO
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public Guid PetType_id { get; set; }
        public string Description { get; set; }
        public Guid Account_id { get; set; }
    }
}
