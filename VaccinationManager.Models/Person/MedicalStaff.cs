using System.ComponentModel.DataAnnotations;

namespace VaccinationManager.Models.Person
{
    public class MedicalStaff
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(11)]
        public int InamiCode { get; set; }

        [Required]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}