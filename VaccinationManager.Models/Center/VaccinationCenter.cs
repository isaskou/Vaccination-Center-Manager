using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Adresse;
using VaccinationManager.Models.Person;

namespace VaccinationManager.Models.Center
{
    public class VaccinationCenter
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(54)]
        public string Name { get; set; }

        [Required]
        public int AdressId { get; set; }
        public Adress Adress { get; set; }

        [Required]
        public int ManagerId { get; set; }
        public MedicalStaff Manager { get; set; }
    }
}
