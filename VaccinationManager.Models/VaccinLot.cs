using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Models
{
    public class VaccinLot
    {
        public int Id { get; set; } //IdLot

        public int VaccinTypeId { get; set; }
        public VaccinType VaccinType { get; set; }
        public int ProviderId { get; set; }
        public VaccinProvider VaccinProvider { get; set; }
        public int InLogId { get; set; }
        public InLog InLog { get; set; }
        public int CenterId { get; set; }
        public VaccinationCenter VaccinationCenter { get; set; }

    }

}
