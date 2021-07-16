using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Center;

namespace VaccinationManager.DAL.DataSet
{
    public class DSVaccinationCenter : IEntityTypeConfiguration<VaccinationCenter>
    {
        public void Configure(EntityTypeBuilder<VaccinationCenter> builder)
        {
            builder.HasData(
                new VaccinationCenter { Id = 1, Name = "PAMexpo", AdressId = 1, ManagerId = 1 },
                new VaccinationCenter { Id=2, Name="CEME", AdressId=2, ManagerId=1},
                new VaccinationCenter { Id=3, Name="Lotto Mons Expo", AdressId=3, ManagerId=1},
                new VaccinationCenter { Id=4, Name="Village Vaccination Ronquières", AdressId=4, ManagerId=1},
                new VaccinationCenter { Id=5, Name="Hall Sportif de Tournai", AdressId=5, ManagerId=1},
                new VaccinationCenter { Id=6, Name="Bierset - Liège Airport", AdressId=6, ManagerId=1},
                new VaccinationCenter { Id=7, Name="Centre sportif de Pepinster", AdressId=7, ManagerId=1},
                new VaccinationCenter { Id=8, Name="WEX", AdressId=8, ManagerId=1},
                new VaccinationCenter { Id=9, Name="Namur Expo", AdressId=9, ManagerId=1}
                ) ;
        }
    }
}
