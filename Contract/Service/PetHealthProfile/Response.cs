using Contract.DTOs.PetHealthProfileDTO;

namespace Contract.Service.PetHealthProfile
{
    public class Response
    {
        public bool Triet_san { get; set; }
        public ICollection<string> Dinh_Duong { get; set; }
        public ICollection<TiemPhongDTO> TiemPhong { get; set; }
        public ICollection<TinhCachDTO> TinhCach { get; set; }
        public ICollection<TinhTrangSKDTO> TinhTrangSK { get; set; }
        public ICollection<XoGiunDTO> XoGiun { get; set; }
    }
}
