using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Models
{
    public class VaccinProvider
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
    }
}
