using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Person;

namespace VaccinationManager.DAL.DataSet
{
    public class DSMedicalStaff : IEntityTypeConfiguration<MedicalStaff>
    {
        public void Configure(EntityTypeBuilder<MedicalStaff> builder)
        {
            builder.HasData(
                new MedicalStaff { Id = 1, InamiCode = 12345678910, StaffId=1 }
                );
        }
    }
}
