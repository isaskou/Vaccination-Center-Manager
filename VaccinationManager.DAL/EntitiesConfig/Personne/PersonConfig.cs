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
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.FirstName)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.Tel)
                .HasMaxLength(10);

            builder.Property(p => p.Email)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(false);

            builder.HasCheckConstraint("CK_Email", "Email LIKE '_%@_%'")
                .HasIndex(p => p.Email)
                .IsUnique();

            builder.Property(p => p.Password)
                .IsRequired();

            builder.Property(p => p.Salt)
                .IsRequired();


        }
    }
}
