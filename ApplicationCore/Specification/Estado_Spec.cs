﻿using ApplicationCore.Entities;
using ApplicationCore.Specification.Filters;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification
{
    public class Estado_Spec : Specification<Paquete>
    {
        public Estado_Spec(Paquete_Filter filter)
        {
            Query.OrderBy(x => x.Contenido_Paquete).ThenByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(filter.Estado_Paquete))
            {
                Query.Search(x => x.Estado_Paquete, filter.Estado_Paquete);
            }
        }
    }
}
