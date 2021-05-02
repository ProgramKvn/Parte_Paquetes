using ApplicationCore.Entities;
using ApplicationCore.Specification.Filters;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification
{
    public class Paquete_Spec : Specification<Paquete>
    {
        public Paquete_Spec(Paquete_Filter filter)
        {
            Query.OrderBy(x => x.Envio_Prioridad);
            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter))
                    .Take(PaginationHelper.CalculateTake(filter));
            if (!string.IsNullOrEmpty(filter.Contenido_Paquete))
            {
                Query.Search(x => x.Contenido_Paquete, "%" + filter.Contenido_Paquete + "%")
                    .Where(x => x.UserId == filter.UserId);
            }
        }
    }
}
