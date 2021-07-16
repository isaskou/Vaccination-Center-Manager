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
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable(nameof(Appointment));

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Date)
                //.HasColumnType("DATE")
                .IsRequired();
            builder.HasCheckConstraint("CK_Date", "[Date]>= GETDATE()");

            builder.HasOne(a => a.FifteenHour)
                .WithMany(fh=>fh.Appointments)
                .HasForeignKey(a=>a.FifteenHourId).OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .IsRequired();

            builder.HasOne(a => a.VaccinType)
                .WithMany(vt => vt.Appointments)
                .HasForeignKey(a => a.VaccinTypeId)
                .IsRequired();

            builder.HasOne(a => a.Center)
                .WithMany(c=>c.Appointments)
                .HasForeignKey(a=>a.CenterId)
                .IsRequired();
        }
    }
}
