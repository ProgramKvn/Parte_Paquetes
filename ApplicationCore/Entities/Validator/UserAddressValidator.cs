using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Validator
{
   public  class userAddressValidator : AbstractValidator<UserAddress>
    {
        public userAddressValidator()
        {
            RuleFor(x => x.ID).NotNull();

            RuleFor(x => x.Departamento).NotNull().WithMessage("Por favor seleccione un Departamento");
            RuleFor(x => x.Municipio).NotNull().WithMessage("Por favor seleccione un Municipio");
            RuleFor(x => x.Direccion).NotNull().WithMessage("Por favor escriba su direccion exacta, incluyendo referencias");
            RuleFor(x => x.IDUsuario).NotNull();
        }
    }
}
