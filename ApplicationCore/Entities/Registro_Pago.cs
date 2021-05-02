using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Registro_Pago
    {
        public int Id_Pago { get; set; }
        public int PaqueteId { get; set; }
        public User User { get; set; }
        public double Monto_Pagado { get; set; }
        public DateTime Fecha_Pago { get; set; }
    }
}
