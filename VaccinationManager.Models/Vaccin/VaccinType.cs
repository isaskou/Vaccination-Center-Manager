using System.ComponentModel.DataAnnotations;

namespace VaccinationManager.Models.Vaccin
{
    public class VaccinType
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(54)]
        public string Name { get; set; }
    }
}