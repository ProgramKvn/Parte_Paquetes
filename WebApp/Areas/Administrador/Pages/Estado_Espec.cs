using ApplicationCore.Entities;
using ApplicationCore.Specification.Filters;
using Ardalis.Specification;

namespace WebApp.Areas.Administrador.Pages
{
    internal class Estado_Espec : ISpecification<Paquete>
    {
        private Paquete_Filter paquete_Filter;

        public Estado_Espec(Paquete_Filter paquete_Filter)
        {
            this.paquete_Filter = paquete_Filter;
        }
    }
}