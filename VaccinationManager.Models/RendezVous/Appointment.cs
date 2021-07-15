using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Center;
using VaccinationManager.Models.Person;
using VaccinationManager.Models.Vaccin;

namespace VaccinationManager.Models.RendezVous
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [Required]
        [Column(TypeName = "Time")]
        [DataType(DataType.Time)]
        public FifteenHour TimeFifteen { get; set; }

        [Required]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public int VaccinTypeId { get; set; }

        public VaccinType VaccinType { get; set; }

        [Required]
        public int CenterId { get; set; }

        public VaccinationCenter Center { get; set; }
    }
}
