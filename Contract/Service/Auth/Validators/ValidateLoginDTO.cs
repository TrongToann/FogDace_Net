using FluentValidation;
using static Contract.Service.Auth.Command;

namespace Contract.Service.Auth.Validators
{
    public class ValidateLoginDTO : AbstractValidator<Login>
    {
        public ValidateLoginDTO()
        {
            RuleFor(p => p.LoginDTO.UserName).NotEmpty().WithMessage("Invalid Username!");
            RuleFor(p => p.LoginDTO.Password).NotEmpty().WithMessage("Invalide Password");
        }
    }
}
