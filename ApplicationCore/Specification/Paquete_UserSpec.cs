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
    public class Paquete_UserSpec : Specification<Paquete>
    {
        public Paquete_UserSpec(Paquete_Filter filter)
        {
            Query.OrderBy(x => x.Envio_Prioridad);
            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter))
                    .Take(PaginationHelper.CalculateTake(filter));
            Query.Search(x => x.Id_Paquete.ToString(), filter.Paquete_Id.ToString()).Where(x => x.UserId == filter.UserId);
        }
    }
}
