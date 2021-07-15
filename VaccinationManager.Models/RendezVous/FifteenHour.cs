using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Models.RendezVous
{
    public class FifteenHour
    {
        [Required]
        [Column(TypeName = "TIME")]
        [DataType(DataType.Time)]
        public Appointment time { get; set; }
    }
}
