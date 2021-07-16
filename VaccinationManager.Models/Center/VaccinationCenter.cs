using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Adresse;
using VaccinationManager.Models.Person;
using VaccinationManager.Models.RendezVous;
using VaccinationManager.Models.Vaccin;

namespace VaccinationManager.Models.Center
{
    public class VaccinationCenter
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        public int AdressId { get; set; }

        //Pour la OneToOne
        public Adress Adress { get; set; }

        [Required]
        public int ManagerId { get; set; }

        //POur la OneToOne
        public MedicalStaff Manager { get; set; }


        //Pour la OneToMany avec l'Horaire
        public IEnumerable<ScheduleCenter> ScheduleCenters { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public IEnumerable<VaccinLot> VaccinLots { get; set; }
    }
}
