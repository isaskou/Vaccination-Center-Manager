using System.ComponentModel.DataAnnotations;

namespace VaccinationManager.Models.Adresse
{
    public class Adress
    {
        public int Id { get; set; }

        [Required]
        [MinLength (1)]
        [MaxLength(255)]
        public string Street { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(10)]
        public string Number { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public int PostalCode { get; set; }
        
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string City { get; set; }
        
        [Required]
        [EnumDataType(typeof(District))]
        public District District { get; set; }
    }
}