using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.RendezVous;

namespace VaccinationManager.DAL.EntitiesConfig.Rendez_vous
{
    public class FifteenHourConfig : IEntityTypeConfiguration<FifteenHour>
    {
        public void Configure(EntityTypeBuilder<FifteenHour> builder)
        {
            builder.ToTable(nameof(FifteenHour));

            builder.HasKey(ft => ft.Id);
            builder.Property(ft => ft.Id).ValueGeneratedOnAdd();

            builder.Property(ft => ft.StartTime)
                .HasColumnType("TIME")
                .IsRequired();

            builder.Property(ft => ft.EndTime)
                .HasColumnType("TIME")
                .IsRequired();
        }
    }
}
