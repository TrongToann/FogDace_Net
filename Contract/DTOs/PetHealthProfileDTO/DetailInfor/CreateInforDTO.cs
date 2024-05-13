namespace Contract.DTOs.PetHealthProfileDTO.DetailInfor
{
    public class CreateInforDTO
    {
        public Guid PetHealthProfile_id { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}
