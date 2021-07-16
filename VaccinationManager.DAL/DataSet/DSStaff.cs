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
    public class DSStaff : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(

                new Staff { Id = 1, Grade = Grade.Medecin, PersonId = 1 }
                );
        }
    }
}
