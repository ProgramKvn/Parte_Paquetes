using ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification.Filters
{
    public class Paquete_Filter : BaseFilter
    {
        public string Contenido_Paquete { get; set; }
        public Tipo_Contenido Tipo_Contenido { get; set; }
        public string Estado_Paquete { get; set; }
        public float Peso_Contenido { get; set; }
    }
}
