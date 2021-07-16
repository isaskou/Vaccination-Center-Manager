using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Person;

namespace VaccinationManager.DAL.EntitiesConfig.Personne
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable(nameof(Patient));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.NationalRegister)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(p => p.DateOfBirth)
                .IsRequired();

            builder.HasOne(p => p.Adress)
                .WithOne(a => a.Patient)
                .HasForeignKey<Patient>(p => p.AdressId)
                .IsRequired();

            builder.Property(p => p.MedicalIndication);

            builder.HasOne(pa => pa.Person)
                .WithMany(pe => pe.Patients)
                .HasForeignKey(pa => pa.PersonId)
                .IsRequired();

        }
    }
}
