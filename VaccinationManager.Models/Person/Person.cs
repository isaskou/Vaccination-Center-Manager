using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccinationManager.Models.Person
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        public string LastName { get; set; }

        [MinLength(9)]
        [MaxLength(10)]
        public string Tel { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VARBINARY(32)")]
        [DataType(DataType.Password)]
        public byte[] Password { get; set; }

// mettre un Repassword ? ou un PasswordIn/PasswordOut ?

        [Required]
        [Column(TypeName = "CHAR(36)")]
        public string Salt { get; set; }
    }
}