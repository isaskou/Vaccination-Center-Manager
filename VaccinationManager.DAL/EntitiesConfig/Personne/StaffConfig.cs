﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Personne;

namespace VaccinationManager.DAL.EntitiesConfig.Personne
{
    public class StaffConfig : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable(nameof(Staff));

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Grade)
                .HasConversion<string>()
                .IsRequired();

            builder.HasOne(s => s.Person)
                .WithMany(p => p.Staffs)
                .HasForeignKey(s=>s.PersonId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(s => s.VaccinationCenter)
                .WithMany(vc => vc.Staffs)
                .HasForeignKey(s => s.VaccinationCenterId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
