using Contract.DTOs.PetTypeDTO;

namespace Contract.Service.Pet
{
    public class Response
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public PetTypeDTO PetType { get; set; }
        public string Description { get; set; }
        public int Is_trading { get; set; }
    }
}
