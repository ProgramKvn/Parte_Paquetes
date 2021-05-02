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
    public class DepSVConfig : IEntityTypeConfiguration<DepSV>
    {
        public void Configure(EntityTypeBuilder<DepSV> builder)
        {   
            builder.ToTable("DEPSV");

            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID)
                .ValueGeneratedNever()
                .IsRequired();
            builder.Property(x => x.DepName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.ISOCode)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(x => x.ZONESV_ID)
                .IsRequired();
        }
    }
}
