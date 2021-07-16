using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Person;
using VaccinationManager.Models.RendezVous;
using VaccinationManager.Models.Vaccin;

namespace VaccinationManager.Models
{
    public class Injection
    {
        public int Id { get; set; }

        [Required]
        public int VaccinLotId { get; set; }
        public VaccinLot VaccinLot { get; set; }

        [Required]
        public int MedicalStaffId { get; set; }
        public MedicalStaff MedicalStaff { get; set; }

        [Required]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

    }
}
