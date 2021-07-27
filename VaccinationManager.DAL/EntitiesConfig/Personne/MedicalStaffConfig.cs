using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Personne;

namespace VaccinationManager.DAL.EntitiesConfig.Personne
{
    public class MedicalStaffConfig : IEntityTypeConfiguration<MedicalStaff>
    {
        public void Configure(EntityTypeBuilder<MedicalStaff> builder)
        {
            builder.ToTable(nameof(MedicalStaff));

            builder.HasKey(ms => ms.Id);
            builder.Property(ms => ms.Id).ValueGeneratedOnAdd();

            builder.Property(ms => ms.InamiCode)
                .HasMaxLength(11)
                .IsRequired();

            builder.HasOne(ms => ms.Staff)
                .WithOne(s => s.MedicalStaff)
                .HasForeignKey<MedicalStaff>(ms => ms.StaffId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            
        }
    }
}
