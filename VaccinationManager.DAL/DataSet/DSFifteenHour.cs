using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.RendezVous;

namespace VaccinationManager.DAL.DataSet
{
    public class DSFifteenHour : IEntityTypeConfiguration<FifteenHour>
    {
        public void Configure(EntityTypeBuilder<FifteenHour> builder)
        {
            //builder.HasData( 
            //    ) ;
        }

        public List<DateTime> BoucleQuartHeure(FifteenHour entity)
        {
            entity = new FifteenHour
            {
                StartTime = entity.StartTime,
                EndTime = entity.EndTime
            };


            List<DateTime> list = new List<DateTime>();

            entity.StartTime = DateTime.Parse("00:15:00");
            TimeSpan quartheure = new TimeSpan(00, 15, 00);

            for (entity.StartTime = DateTime.Parse("00:00:00"); entity.EndTime <= DateTime.Parse("23:45:00");)
            {
                entity.Id = entity.Id++;
                entity.EndTime = entity.StartTime + quartheure;

                entity.StartTime = entity.EndTime;

                entity.EndTime = entity.StartTime + quartheure;

                list.Add(entity.EndTime);
            }

            return list;

        }
    }
}
