using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Adresse;

namespace VaccinationManager.DAL.DataSet
{
    public class DSAdress : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.HasData(
                new Adress { Id = 1, Street = "Boucle Joseph Dewez", Number = "2", City = "Court-Saint-Etienne", PostalCode = 1490, District = District.BrabantWallon },
                new Adress { Id = 2, Street = "Esplanade du Conseil de l’Europe", Number = "-", City = "Charleroi", PostalCode = 6000, District = District.Hainaut },
                new Adress { Id = 3, Street = "Avenue Thomas Edison", Number = "2", City = "Mons", PostalCode = 7000, District = District.Hainaut },
                new Adress { Id = 4, Street = "Rue Rosemont", Number = "1", City = "Ronquières", PostalCode = 7090, District = District.Hainaut },
                new Adress { Id = 5, Street = "Avenue de Gaulle", Number = "2", City = "Tournai", PostalCode = 7500, District = District.Hainaut },
                new Adress { Id = 6, Street = "Rue de l’Aéroport", Number = "1", City = "Grâce-Hollogne", PostalCode = 4460, District = District.Liège },
                new Adress { Id = 7, Street = "Rue du Paire", Number = "1", City = "Pepinster", PostalCode = 4860, District = District.Liège },
                new Adress { Id = 8, Street = "Rue des Deux Provinces", Number = "1", City = "Marche-en-Famenne", PostalCode = 6900, District = District.Luxembourg },
                new Adress { Id = 9, Street = "Avenue Sergent Vrithoff", Number = "2", City = "Namur", PostalCode = 5000, District = District.Namur }
                ) ; 
        }
    }
}
