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
    public class InLogConfig : IEntityTypeConfiguration<InLog>
    {
        public void Configure(EntityTypeBuilder<InLog> builder)
        {
            builder.ToTable(nameof(InLog));

            builder.HasKey(il => il.Id);
            builder.Property(il => il.Id).ValueGeneratedOnAdd();

            builder.Property(il => il.InDate)
                //.HasColumnType("DATETIME")
                .IsRequired();
            builder.HasCheckConstraint("CK_InDate", "InDate>=GetDate()");

            builder.Property(il => il.Quantity)
                .IsRequired();
            builder.HasCheckConstraint("CK_Quantity", "Quantity>0");

        }
    }
}
