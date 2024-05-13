using FluentValidation;
using static Contract.Service.Pet.Command;

namespace Contract.Service.Pet.Validators
{
    public class UpdatePetCommandValidator : AbstractValidator<UpdatePet>
    {
        public UpdatePetCommandValidator()
        {
            RuleFor(x => x.Pet_id).NotEmpty();
            RuleFor(x => x.UpdatePetDTO.Name).NotEmpty();
            RuleFor(x => x.UpdatePetDTO.Avatar).NotEmpty();
            RuleFor(x => x.UpdatePetDTO.Gender).NotEmpty();
            RuleFor(x => x.UpdatePetDTO.Birthday).NotEmpty();
            RuleFor(x => x.UpdatePetDTO.Description).NotEmpty();
    }
    }
}
