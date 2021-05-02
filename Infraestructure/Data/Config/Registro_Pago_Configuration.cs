using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Config
{
    public class Registro_Pago_Configuration : IEntityTypeConfiguration<Registro_Pago>
    {
        public void Configure(EntityTypeBuilder<Registro_Pago> builder) 
        {
            builder.ToTable("Registro_Pagos");
            builder.HasKey(x => x.Id_Pago);
            builder.Property(x => x.PaqueteId)
                .IsRequired();
            builder.Property(x => x.Monto_Pagado)
                .IsRequired();
            builder.Property(x => x.Fecha_Pago)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
