using FluentValidation;
using static Contract.Service.PetHealthProfile.Command;

namespace Contract.Service.PetHealthProfile.Validators
{
    public class UpdatePetHealthProfileValidator : AbstractValidator<UpdatePetHealthProfile>
    {
        public UpdatePetHealthProfileValidator()
        {
            RuleFor(x => x.PetHealthProfile_id).NotEmpty();
            RuleFor(x => x.UpdatePetHealthProfileDTO.Triet_san).NotEmpty();
        }
    }
}
