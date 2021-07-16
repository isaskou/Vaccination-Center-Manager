using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Adresse;

namespace VaccinationManager.Models.Vaccin
{
    public class VaccinProvider
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        public int AdressId { get; set; }
        public Adress Adress { get; set; }


        //Pour la one to many
        public IEnumerable<VaccinLot> VaccinLots { get; set; }
    }
}
