using ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Paquete
    {
        public int Id { get; set; }
        public string String_Fotografia { get; set; }
        public string Nombre_Fotografia() {
            return Contenido_Paquete + '-' + Guid.NewGuid().ToString();
        }
        public string Contenido_Paquete { get; set; }
        public Tipo_Contenido Tipo_Contenido { get; set; }
        public string Estado_Paquete { get; set; }
        public bool Envio_Prioridad { get; set; }
        public double Peso_Contenido { get; set; }
        //Envio_Prioridad significa un envío rápido, con una mayor tarifa al precio normal
        private double _Monto_A_Pagar;
        public double Monto_Pagar_Function()
        {
            double Limite_Peso;
            double Tarifa;
            if(Envio_Prioridad == true)
            {
                Tarifa = 22.79;
                Limite_Peso = 35;
                if (Peso_Contenido > Limite_Peso)
                {
                    for (int i = 0; i <= Peso_Contenido; i++)
                    {
                        if(i > Limite_Peso)
                            Tarifa += 0.63;
                    }
                    return Math.Round(Tarifa, 2);
                }
                else
                {
                    return Tarifa;
                }
            }
            else
            {
                Tarifa = 9.99;
                Limite_Peso = 20;
                if (Peso_Contenido > Limite_Peso)
                {
                    for (int i = 0; i <= Peso_Contenido; i++)
                    {
                        if(i > Limite_Peso)
                            Tarifa += 0.83;
                    }
                    return Math.Round(Tarifa, 2);
                }
                else
                {
                    return Tarifa;
                }
            }
        }
        public double Monto_Pagar_Prop {
            get
            {
                _Monto_A_Pagar = Monto_Pagar_Function();
                return _Monto_A_Pagar;
            }
            set
            {
                _Monto_A_Pagar = Monto_Pagar_Function();
            } 
        }
        public bool Estado_Pago { get; set; }
        public DateTime Fecha_Entrega { get; set; }
    }
}
