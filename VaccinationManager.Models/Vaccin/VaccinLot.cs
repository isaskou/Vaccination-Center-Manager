using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Center;

namespace VaccinationManager.Models.Vaccin
{
    public class VaccinLot
    {
        public int Id { get; set; } //IdLot

        [Required]
        public int VaccinTypeId { get; set; }
        public VaccinType VaccinType { get; set; }

        [Required]
        public int ProviderId { get; set; }
        public VaccinProvider VaccinProvider { get; set; }

        [Required]
        public int InLogId { get; set; }
        public InLog InLog { get; set; }

        [Required]
        public int CenterId { get; set; }
        public VaccinationCenter VaccinationCenter { get; set; }

    }

}
