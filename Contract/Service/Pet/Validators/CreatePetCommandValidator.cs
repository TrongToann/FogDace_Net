using FluentValidation;
using static Contract.Service.Pet.Command;

namespace Contract.Service.Pet.Validators
{
    public class CreatePetCommandValidator : AbstractValidator<CreatePet>
    {
        public CreatePetCommandValidator()
        {
            RuleFor(x => x.CreatePetDTO.Name).NotEmpty().MinimumLength(2).MaximumLength(50).WithMessage("Name must contain value!");
            RuleFor(x => x.CreatePetDTO.Avatar).NotEmpty().MinimumLength(2).MaximumLength(50).WithMessage("Avatar must contain value!");
            RuleFor(x => x.CreatePetDTO.Birthday).NotEmpty().WithMessage("Birthday must contain value!");
            RuleFor(x => x.CreatePetDTO.Gender).NotEmpty().LessThanOrEqualTo(1).GreaterThanOrEqualTo(0).WithMessage("Gender must contain value!");
            RuleFor(x => x.CreatePetDTO.PetType_id).NotEmpty().WithMessage("Type must contain value!");
            RuleFor(x => x.CreatePetDTO.Description).NotEmpty().MinimumLength(2).MaximumLength(50).WithMessage("Description must contain value!");
            RuleFor(x => x.CreatePetDTO.Account_id).NotEmpty().WithMessage("Account must contain value!");
        }
    }
}
