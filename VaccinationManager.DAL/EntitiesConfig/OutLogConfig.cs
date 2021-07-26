using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models;

namespace VaccinationManager.DAL.EntitiesConfig
{
    public class OutLogConfig : IEntityTypeConfiguration<OutLog>
    {
        public void Configure(EntityTypeBuilder<OutLog> builder)
        {
            builder.ToTable(nameof(OutLog));

            builder.HasKey(ol => ol.Id);
            builder.Property(ol => ol.Id).ValueGeneratedOnAdd();

            builder.Property(ol => ol.OutDate)
                //.HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(ol => ol.Quantity)
                .IsRequired();
            builder.HasCheckConstraint("CK_OutDateQuantity", "Quantity >0");

            builder.HasOne(ol => ol.VaccinLot)
                .WithMany(vl => vl.OutLogs)
                .HasForeignKey(ol => ol.VaccinLotId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
