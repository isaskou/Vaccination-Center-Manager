using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Center;

namespace VaccinationManager.DAL.EntitiesConfig.Center
{
    public class ScheduleCenterConfig : IEntityTypeConfiguration<ScheduleCenter>
    {
        public void Configure(EntityTypeBuilder<ScheduleCenter> builder)
        {
            builder.ToTable(nameof(ScheduleCenter));

            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.Id).ValueGeneratedOnAdd();

            builder.Property(sc => sc.Day)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(sc => sc.OpenHour)
                //.HasColumnType("TIME")
                .IsRequired();

            builder.Property(sc => sc.CloseHour)
                //.HasColumnType("TIME")
                .IsRequired();

            builder.Property(sc => sc.CenterId)
                .IsRequired();

            builder.HasOne(sc => sc.Center)
                .WithMany(vc => vc.ScheduleCenters)
                .HasForeignKey(sc => sc.CenterId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            

        }
    }
}
