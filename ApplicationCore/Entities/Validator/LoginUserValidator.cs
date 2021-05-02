using ApplicationCore.Entities.NoMapped;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Validator
{
    public class LoginUserValidator : AbstractValidator<LoginUser>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.email).NotNull().WithMessage("Escriba su correo electronico.")
                .EmailAddress().WithMessage("Escriba un correo electronico válido");

            RuleFor(x => x.password).NotNull().WithMessage("Escriba su contraseña.");

        }
    }
}
