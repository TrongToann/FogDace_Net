using FluentValidation;
using static Contract.Service.PetHealthProfile.Command;

namespace Contract.Service.PetHealthProfile.Validators.DetailInfor
{
    public class SetNewTinhTrangSKValidator : AbstractValidator<SetNewTinhTrangSK>
    {
        public SetNewTinhTrangSKValidator()
        {
            RuleFor(x => x.CreateInforDTO.PetHealthProfile_id).NotEmpty();
            RuleFor(x => x.CreateInforDTO.Note).NotEmpty();
            RuleFor(x => x.CreateInforDTO.Date).NotEmpty();
        }
    }
}
