﻿using FluentValidation;

namespace MP.ApiDotnet6.Application.DTOs.Validations
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("E-mail deve ser informado");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password deve ser informado");
        }
    }
}
