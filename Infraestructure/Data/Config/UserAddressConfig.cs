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
    public class UserAddressConfig : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Direccion).IsRequired();
            builder.Property(x => x.Departamento).IsRequired();
            builder.Property(x => x.Municipio).IsRequired();
            builder.Property(x => x.IDUsuario).IsRequired();
        }
    }
}
