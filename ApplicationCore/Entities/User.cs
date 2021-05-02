using ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int ID { get; set; }
        public List<Paquete> Paquetes { get; set; }
        public List<Registro_Pago> Registro_Pago { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Genero Genero { get; set; }
        public string DUI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string salt { get; set; }
        public string Rol { get; set; }
        public string confirmContraseña { get; set; }
        public string Fotografia { get; set; }
        public string NombreCompleto()
        {
            return Nombre + ' ' + Apellido;
        }

        public string NombreFotografia()
        {
            return NombreCompleto() + '-' + Guid.NewGuid().ToString();
        }
    }
}
