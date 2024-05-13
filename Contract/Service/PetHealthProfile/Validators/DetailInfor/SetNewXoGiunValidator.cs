﻿using FluentValidation;
using static Contract.Service.PetHealthProfile.Command;

namespace Contract.Service.PetHealthProfile.Validators.DetailInfor
{
    internal class SetNewXoGiunValidator : AbstractValidator<SetNewXoGiun>
    {
        public SetNewXoGiunValidator()
        {
            RuleFor(x => x.CreateInforDTO.PetHealthProfile_id).NotEmpty();
            RuleFor(x => x.CreateInforDTO.Note).NotEmpty();
            RuleFor(x => x.CreateInforDTO.Date).NotEmpty();
        }
    }
}
