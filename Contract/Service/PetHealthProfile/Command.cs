using Contract.Abstraction.Message;
using Contract.DTOs.PetHealthProfileDTO;
using Contract.DTOs.PetHealthProfileDTO.DetailInfor;

namespace Contract.Service.PetHealthProfile
{
    public static class Command
    {
        public record CreatePetHealthProfile(CreatePetHealthProfileDTO CreatePetHealthProfileDTO, Guid Account_id) 
            : ICommand { }
        public record UpdatePetHealthProfile(Guid PetHealthProfile_id, UpdatePetHealthProfileDTO UpdatePetHealthProfileDTO, 
            Guid Account_id) : ICommand<Response> { }
        public record SetNewTiemPhong(CreateInforDTO CreateInforDTO) : ICommand<Response> { }
        public record SetNewTinhTrangSK(CreateInforDTO CreateInforDTO) : ICommand<Response> { }
        public record SetNewXoGiun(CreateInforDTO CreateInforDTO) : ICommand<Response> { }
        public record SetNewTinhCach(CreateInforDTO CreateInforDTO) : ICommand<Response> { }
        public record UpdateTiemPhong() : ICommand<Response> { }
        public record UpdateTinhCach() : ICommand<Response> { }
        public record UpdateTinhTrangSK() : ICommand<Response> { }
        public record UpdateXoGiun() : ICommand<Response> { }
        public record RemoveTiemPhong() : ICommand<Response> { }
        public record RemoveTinhCach() : ICommand<Response> { }
        public record RemoveTinhTrangSK() : ICommand<Response> { }
        public record RemoveXoGiun() : ICommand<Response> { }
    }
}
