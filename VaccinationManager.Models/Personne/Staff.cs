using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaccinationManager.Models.Center;

namespace VaccinationManager.Models.Personne
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        [EnumDataType(typeof(Grade))]
        public Grade Grade { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int VaccinationCenterId { get; set; }
        public VaccinationCenter VaccinationCenter { get; set; }

        //Pour les OneToOne
        public MedicalStaff MedicalStaff { get; set; } 
        
    }
}