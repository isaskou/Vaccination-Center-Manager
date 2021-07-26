using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Adresse;
using VaccinationManager.Models.Center;

namespace VaccinationManager.DAL.EntitiesConfig.Center
{
    public class VaccinationCenterConfig : IEntityTypeConfiguration<VaccinationCenter>
    {
        public void Configure(EntityTypeBuilder<VaccinationCenter> builder)
        {
            builder.ToTable(nameof(VaccinationCenter));

            builder.HasKey(vc => vc.Id);
            builder.Property(vc => vc.Id).ValueGeneratedOnAdd();

            builder.Property(vc => vc.Name)
                .HasMaxLength(64)
                .IsRequired();

           builder.HasOne(vc => vc.Adress)
                .WithOne(a => a.VaccinationCenter)
                .HasForeignKey<VaccinationCenter>(vc=>vc.AdressId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(vc => vc.Manager)
                .WithOne(ms => ms.VaccinationCenter)
                .HasForeignKey<VaccinationCenter>(vc=>vc.ManagerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
