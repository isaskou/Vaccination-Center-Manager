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
        //[Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int FifteenHourId { get; set; }

        public FifteenHour FifteenHour { get; set; }

        //[Required]
        //[Column(TypeName = "Time")]
        //[DataType(DataType.Time)]
        //public FifteenHour StartTime { get; set; }
        //[Required]
        //[Column(TypeName = "Time")]
        //[DataType(DataType.Time)]

        //public FifteenHour EndTime { get; set; }

        [Required]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public int VaccinTypeId { get; set; }

        public VaccinType VaccinType { get; set; }

        [Required]
        public int CenterId { get; set; }

        public VaccinationCenter Center { get; set; }
        public int InjectionId { get; set; }

        //Pour la one to One
        public Injection Injection { get; set; }
    }
}
