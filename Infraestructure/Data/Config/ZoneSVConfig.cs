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
    public class ZoneSVConfig : IEntityTypeConfiguration<ZoneSV>
    {
        public void Configure(EntityTypeBuilder<ZoneSV> builder)
        {
            builder.ToTable("ZONESV");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID)
                .ValueGeneratedNever()
                .IsRequired();
            builder.Property(x => x.ZoneName)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
