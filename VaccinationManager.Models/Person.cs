using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccinationManager.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        public string Tel { get; set; }


        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VARBINARY(32)")]
        public byte[] Password { get; set; }

        [Required]
        [Column(TypeName = "CHAR(36)")]
        public string Salt { get; set; }
    }
}