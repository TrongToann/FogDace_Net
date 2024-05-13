using FluentValidation;
using static Contract.Service.PetHealthProfile.Command;

namespace Contract.Service.PetHealthProfile.Validators
{
    public class CreatePetHealthProfileValidator : AbstractValidator<CreatePetHealthProfile>
    {
        public CreatePetHealthProfileValidator()
        {
            RuleFor(x => x.CreatePetHealthProfileDTO.Pet_id).NotEmpty();
            RuleFor(x => x.CreatePetHealthProfileDTO.InputDinhDuong).NotEmpty();
            RuleFor(x => x.CreatePetHealthProfileDTO.InputTinhCach).NotEmpty();
            RuleFor(x => x.CreatePetHealthProfileDTO.InputTiemPhong).NotEmpty();
            RuleFor(x => x.CreatePetHealthProfileDTO.InputTinhTrangSK).NotEmpty();
            RuleFor(x => x.CreatePetHealthProfileDTO.Triet_san).NotEmpty();
            RuleFor(x => x.CreatePetHealthProfileDTO.InputXoGiun).NotEmpty();
        }
    }
}
