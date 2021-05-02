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
    public class MunSVConfig : IEntityTypeConfiguration<MunSV>
    {
        public void Configure(EntityTypeBuilder<MunSV> builder)
        {
            builder.ToTable("MUNSV");

            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID)
                .ValueGeneratedNever()
                .IsRequired();
            builder.Property(x => x.MunName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.DEPSV_ID).IsRequired();
        }
    }
}
