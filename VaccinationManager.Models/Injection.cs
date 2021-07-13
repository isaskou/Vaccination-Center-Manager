using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Models
{
    public class Injection
    {
        public int Id { get; set; }
        public int VaccinLotId { get; set; }
        public VaccinLot VaccinLot { get; set; }
        public int MedicalStaffId { get; set; }
        public MedicalStaff MedicalStaff { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
