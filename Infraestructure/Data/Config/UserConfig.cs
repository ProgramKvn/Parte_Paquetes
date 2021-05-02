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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
         
            builder.ToTable("Users");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.Nombre)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.Apellido)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Telefono).IsRequired();

            builder.Property(x => x.DUI).IsRequired().HasMaxLength(10);
            builder.HasIndex(x => x.DUI).IsUnique();

            builder.Property(x => x.Genero).IsRequired();

            builder.Property(x => x.FechaNacimiento).IsRequired();

            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Contraseña).IsRequired();
            builder.Ignore(x => x.confirmContraseña);

            builder.Property(x => x.salt).HasColumnName("Salt");

            builder.Property(x => x.Rol).HasDefaultValue("Cliente");

            builder.Property(ci => ci.Fotografia)
                .HasDefaultValue("https://localhost:44356/Uploads/Usuarios/user-icon-default.png");

        }
    }
}
