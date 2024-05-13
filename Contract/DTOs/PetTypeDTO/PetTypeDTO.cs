using Contract.DTOs.BaseDTO;

namespace Contract.DTOs.PetTypeDTO
{
    public class PetTypeDTO : Base, IPetTypeDTO
    {
        public string Type { get; set; }
        public string Image { get; set; }
    }
}
