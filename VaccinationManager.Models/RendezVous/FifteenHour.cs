using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Models.RendezVous
{
    public class FifteenHour
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Time)]
        //[Column(TypeName ="TIME")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        //[Column(TypeName = "TIME")]

        public DateTime EndTime { get; set; }

        //[Required]
        //[Column(TypeName = "TIME")]
        //[DataType(DataType.Time)]
        //public DateTime time { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

    }
}
