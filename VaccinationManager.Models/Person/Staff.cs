using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaccinationManager.Models.Person
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

        //Pour les OneToMany
        public IEnumerable<MedicalStaff> medicalStaffs { get; set; } 
    }
}