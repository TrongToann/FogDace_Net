namespace Contract.DTOs.PetHealthProfileDTO
{
    public class CreatePetHealthProfileDTO : IPetHealthProfileDTO
    {
        public Guid Pet_id { get; set; }
        public int Triet_san { get; set; }
        public ICollection<InputInformationWithouDate> InputDinhDuong { get; set; }
        public ICollection<InputInformation> InputTiemPhong { get; set; }
        public ICollection<InputInformation> InputTinhCach { get; set; }
        public ICollection<InputInformation> InputTinhTrangSK { get; set; }
        public ICollection<InputInformationWithouNote> InputXoGiun { get; set; }
    }
    public class InputInformation
    {
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
    public class InputInformationWithouNote
    {
        public DateTime Date { get; set; }
    }
    public class InputInformationWithouDate
    {
        public string Note { get; set; }
    }

}
