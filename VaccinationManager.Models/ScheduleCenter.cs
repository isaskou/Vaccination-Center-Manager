using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Models
{
    public class ScheduleCenter
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public DateTime OpenHour { get; set; }
        public DateTime CloseHour { get; set; }
        public int CenterId { get; set; }
        public VaccinationCenter Center { get; set; }
    }
}
