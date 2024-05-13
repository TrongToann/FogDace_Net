using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("PetHealthProfile")]
    public class PetHealthProfile : EntityBase<Guid>
    {
        [ForeignKey(nameof(Pet))]
        public Guid Pet_id { get; set; }
        public Pet Pet { get; set; }
        public int Triet_san {  get; set; }
        public ICollection<DinhDuong> DinhDuong {  get; set; }
        public ICollection<TiemPhong> TiemPhong { get; set; }
        public ICollection<TinhCach> TinhCach { get; set; }
        public ICollection<TinhTrangSK> TinhTrangSK { get; set; }
        public ICollection<XoGiun> XoGiun { get; set; }
    }
}
