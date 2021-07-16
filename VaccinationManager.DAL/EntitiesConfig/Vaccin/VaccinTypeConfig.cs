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
    public class VaccinTypeConfig : IEntityTypeConfiguration<VaccinType>
    {
        public void Configure(EntityTypeBuilder<VaccinType> builder)
        {
            builder.ToTable(nameof(VaccinType));

            builder.HasKey(vt => vt.Id);
            builder.Property(vt => vt.Id).ValueGeneratedOnAdd();

            builder.Property(vt => vt.Name)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}
