using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Personne;
using VaccinationManager.Tools;
using VaccinationManager.Tools.SecurityTools;

namespace VaccinationManager.DAL.DataSet
{

    public class DSPerson : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            Person person1 = new Person
            {
                Id = 1,
                FirstName = "Isabel",
                LastName = "Skou",
                Email = "isabel@mail.be",
                Salt = Guid.NewGuid().ToString()
            };
            person1.Password = PasswordHasher.Hashing<Person>(person1, "test1234=", p => p.Salt);
            builder.HasData(person1);
        }
    }
}
