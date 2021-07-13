using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeFifteen { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int VaccinTypeId { get; set; }
        public VaccinType VaccinType { get; set; }
        public int CenterId { get; set; }
        public VaccinationCenter Center { get; set; }
    }
}
