namespace Contract.DTOs.PetTypeDTO
{
    public interface IPetTypeValueDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public int Life_span { get; set; }
        public decimal Weight { get; set; }
    }
}
