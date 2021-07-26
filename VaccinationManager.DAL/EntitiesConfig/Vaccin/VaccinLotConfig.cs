using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Vaccin;

namespace VaccinationManager.DAL.EntitiesConfig.Vaccin
{
    public class VaccinLotConfig : IEntityTypeConfiguration<VaccinLot>
    {
        public void Configure(EntityTypeBuilder<VaccinLot> builder)
        {
            builder.ToTable(nameof(VaccinLot));

            builder.HasKey(vl => vl.Id);
            builder.Property(vl => vl.Id).ValueGeneratedOnAdd();

            builder.HasOne(vl => vl.VaccinType)
                .WithMany(vt => vt.VaccinLots)
                .HasForeignKey(vl => vl.VaccinTypeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(vl => vl.VaccinProvider)
                .WithMany(vp => vp.VaccinLots)
                .HasForeignKey(vl => vl.ProviderId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(vl => vl.InLog)
                .WithMany(il => il.VaccinLots)
                .HasForeignKey(vl => vl.InLogId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(vl => vl.VaccinationCenter)
                .WithMany(vc => vc.VaccinLots)
                .HasForeignKey(vl => vl.CenterId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
