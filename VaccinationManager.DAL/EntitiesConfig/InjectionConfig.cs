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
    public class InjectionConfig : IEntityTypeConfiguration<Injection>
    {
        public void Configure(EntityTypeBuilder<Injection> builder)
        {
            builder.ToTable(nameof(Injection));

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.HasOne(i => i.VaccinLot)
                .WithMany(vl => vl.Injections)
                .HasForeignKey(i => i.VaccinLotId)
                .IsRequired();

            builder.HasOne(i => i.MedicalStaff)
                .WithMany(ms => ms.Injections)
                .HasForeignKey(i => i.MedicalStaffId)
                .IsRequired();

            builder.HasOne(i => i.Appointment)
                .WithOne(a => a.Injection)
                .HasForeignKey<Injection>(i => i.AppointmentId)
                .IsRequired();


        }
    }
}
