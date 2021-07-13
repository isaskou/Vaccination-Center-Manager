using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Models
{
    public class OutLog
    {
        public int Id { get; set; }
        public DateTime OutDate { get; set; }
        public int Quantity { get; set; }
        public int VaccinLotId { get; set; }
        public VaccinLot VaccinLot { get; set; }
    }
}
