using FluentValidation;
using static Contract.Service.PetType.Command;

namespace Contract.Service.PetType.Validators
{
    public class CreatePetTypeValidator : AbstractValidator<CreatePetType>
    {
        public CreatePetTypeValidator()
        {
            RuleFor(x => x.CreatePetTypeDTO.Type).NotEmpty();
            RuleFor(x => x.CreatePetTypeDTO.Image).NotEmpty();
            //RuleFor(x => x.CreatePetTypeDTO.PetTypeValues)
            //    .Must(value => value.All(value => !string.IsNullOrEmpty(value.Name)))
            //    .Must(value => value.All(value => !string.IsNullOrEmpty(value.Image)))
            //    .Must(value => value.All(value => !string.IsNullOrEmpty(value.Description)))
            //    .Must(value => value.All(value => !string.IsNullOrEmpty(value.Origin)))
            //    .Must(value => value.All(op => op.Life_span > 1))
            //    .WithMessage("Invalid Data Of PetTypeValue!");
        }
    }
}
