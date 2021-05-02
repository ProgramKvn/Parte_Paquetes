using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class UserAddress
    {
        public int ID { get; set; }
        public int IDUsuario { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string CodigoPostal { get; set; }
        public string Direccion { get; set; }
        public string Origen()
        {
            return Departamento + ", " + Municipio + ". " + Direccion;
        }
    }
}
