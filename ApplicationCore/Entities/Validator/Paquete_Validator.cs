using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Validator
{
    public class Paquete_Validator : AbstractValidator<Paquete>
    {
        public Paquete_Validator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Contenido_Paquete).NotNull().WithMessage("Este campo no puede enviarse vacío.")
                .Length(2, 150).WithMessage("Este campo debe de contener de 2 a 255 caracteres.");
            RuleFor(x => x.Tipo_Contenido).IsInEnum().WithMessage("Este campo no puede enviarse vacío.");
            RuleFor(x => x.Peso_Contenido).NotNull().WithMessage("Este campo no puede enviarse vacío.");
            RuleFor(x => x.Envio_Prioridad).NotNull().WithMessage("Este campo no puede enviarse vacío.");
            RuleFor(x => x.Fecha_Entrega)
                .NotNull().WithMessage("Este campo no puede enviarse vacío.")
                .GreaterThan(DateTime.Now).WithMessage("No es posible aceptar una fecha menor a la fecha actual.");
            RuleFor(x => x.Monto_Pagar_Prop).NotNull().WithMessage("Este campo no puede enviarse vacío.");
        }
    }
}
