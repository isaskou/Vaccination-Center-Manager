using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaccinationManager.Models.Center;

namespace VaccinationManager.Models.Personne
{
    public class MedicalStaff
    {
        public int Id { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public long InamiCode { get; set; }

        [Required]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        
        //Pour la oneToOne avec VaccinationCenter (responsable)
        public VaccinationCenter VaccinationCenter { get; set; }

        //Pour la one to many
        public IEnumerable<Injection> Injections { get; set; }
    }
}