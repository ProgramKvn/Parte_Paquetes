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
    public class Paquete_Configuration : IEntityTypeConfiguration<Paquete>
    {
        public void Configure(EntityTypeBuilder<Paquete> builder)
        {
            builder.ToTable("Paquetes");
            builder.HasKey(c => c.Id_Paquete);
            builder.Property(c => c.Contenido_Paquete)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(c => c.String_Fotografia);
            builder.Property(c => c.Tipo_Contenido)
                .IsRequired();
            builder.Property(c => c.Peso_Contenido)
                .IsRequired();
            builder.Property(c => c.Estado_Paquete)
                .HasDefaultValue("Pendiente");
            builder.Property(c => c.Envio_Prioridad)
                .IsRequired();
            builder.Property(c => c.Monto_Pagar_Prop)
                .IsRequired();
            builder.Property(c => c.Estado_Pago)
                .HasDefaultValue(false);
            builder.Property(c => c.Fecha_Entrega)
                .IsRequired();
            builder.Property(c => c.Origen)
                .IsRequired();
            builder.Property(c => c.Destino)
                .IsRequired();
            builder.Property(c => c.Departamento)
                .IsRequired();
            builder.Property(c => c.Municipio)
                .IsRequired();
        }
    }
}
