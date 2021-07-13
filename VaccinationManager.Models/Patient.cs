using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public char NationalRegister { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
        public string MedicalIndication { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}
