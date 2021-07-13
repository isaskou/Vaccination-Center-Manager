using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Models
{
    public class VaccinationCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AdressId { get; set; }
        public Adress Adress { get; set; }

        public int ManagerId { get; set; }
        public MedicalStaff Manager { get; set; }
    }
}
