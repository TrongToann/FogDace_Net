using FluentValidation;
using static Contract.Service.Auth.Command;

namespace Contract.Service.Auth.Validators
{
    public class ValidateRegisterDTO : AbstractValidator<Register>
    {
        public ValidateRegisterDTO()
        {
            RuleFor(x => x.RegisterDTO.Username).NotEmpty();
            RuleFor(x => x.RegisterDTO.FullName).NotEmpty();
            RuleFor(x => x.RegisterDTO.Password).NotEmpty();
            RuleFor(x => x.RegisterDTO.ConfirmPassword).NotEmpty();
        }
    }
}
