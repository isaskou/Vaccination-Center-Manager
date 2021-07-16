using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaccinationManager.Models.RendezVous;

namespace VaccinationManager.Models.Vaccin
{
    public class VaccinType
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        public string Name { get; set; }

        //Pour la OneToMany
        public IEnumerable<Appointment> Appointments { get; set; }

        public IEnumerable<VaccinLot> VaccinLots { get; set; }
    }
}