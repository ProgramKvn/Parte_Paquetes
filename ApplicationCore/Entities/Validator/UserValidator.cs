using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.ID).NotNull();

            RuleFor(x => x.Nombre).NotNull().WithMessage("El nombre es requerido.")
            .Length(3, 50).WithMessage("El nombre debe tener entre 3 y 50 carácteres");

            RuleFor(x => x.Apellido).NotNull().WithMessage("El apellido es requerido.")
            .Length(3, 50).WithMessage("El apellido debe tener entre 3 y 50 carácteres");

            RuleFor(x => x.Email).NotNull().WithMessage("Es necesario tener un correo electronico.")
                .EmailAddress().WithMessage("Por favor ingrese un correo electronico válido");

            RuleFor(x => x.Contraseña).NotNull().WithMessage("Es necesario una contraseña.")
                .Equal(c => c.confirmContraseña).WithMessage("Las contraseñas no coinciden.")
                .Length(8, 64).WithMessage("La contraseña debe tener entre 8 y 64 carácteres");

            RuleFor(x => x.confirmContraseña).NotNull().WithMessage("Este campo no puede quedar vacio.")
                .Equal(c => c.Contraseña).WithMessage("Las contraseñas no coinciden.");
           
            RuleFor(x => x.DUI).NotNull().WithMessage("Es necesario llenar este campo")
                .Length(10).WithMessage("Ingrese un número de DUI válido");

            RuleFor(x => x.Telefono).NotNull().WithMessage("El campo no puede quedar vacio")
                .Length(9).WithMessage("Ingrese un número telefónico válido");
            
            RuleFor(x => x.Genero).IsInEnum().NotNull().WithMessage("Por favor, seleccione un género");

            RuleFor(x => x.FechaNacimiento).NotNull().WithMessage("La fecha de nacimiento es requerida")
                .When(x => x.FechaNacimiento.AddYears(18) < DateTime.Now).WithMessage("Debe tener mas de 18 años para registrarse.");



                
        }
    }
}
