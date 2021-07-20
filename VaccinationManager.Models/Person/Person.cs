using System.Collections.Generic;
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

        public string Token { get; set; }

        public byte[] Password { get; set; }
        public string Salt { get; set; }

        //Pour les OneToMany
        public virtual IEnumerable<Staff> Staffs { get; set; } 
        public virtual IEnumerable<Patient> Patients { get; set; }
    }
}