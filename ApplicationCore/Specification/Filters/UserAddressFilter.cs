using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification.Filters
{
    public class UserAddressFilter : BaseFilter
    {
        public int IDUsuario { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
    }
}
