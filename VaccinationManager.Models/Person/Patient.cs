using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Adresse;
using VaccinationManager.Models.RendezVous;

namespace VaccinationManager.Models.Person
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string NationalRegister { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int AdressId { get; set; }
        public Adress Adress { get; set; }

        [MinLength(2)]
        [MaxLength(1000)]
        public string MedicalIndication { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }


        //Pour la One to Many
        public IEnumerable<Appointment> Appointments { get; set; }

    }
}
