using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Adresse;

namespace VaccinationManager.DAL.EntitiesConfig.Adresse
{
    public class AdressConfig : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.ToTable(nameof(Adress));

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Street)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(a => a.Number)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(a => a.PostalCode)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(a => a.City)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(a => a.District)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
