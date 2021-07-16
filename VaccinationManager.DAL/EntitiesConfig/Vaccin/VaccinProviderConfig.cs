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
    public class VaccinProviderConfig : IEntityTypeConfiguration<VaccinProvider>
    {
        public void Configure(EntityTypeBuilder<VaccinProvider> builder)
        {
            builder.ToTable(nameof(VaccinProvider));

            builder.HasKey(vp => vp.Id);
            builder.Property(vp => vp.Id).ValueGeneratedOnAdd();

            builder.Property(vp => vp.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasOne(vp => vp.Adress)
                .WithOne(a => a.VaccinProvider)
                .HasForeignKey<VaccinProvider>(vp => vp.AdressId)
                .IsRequired();
        }
    }
}
