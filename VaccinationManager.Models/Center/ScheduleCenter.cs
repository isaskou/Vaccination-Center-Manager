using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Models.Center
{
    public class ScheduleCenter
    {
        public int Id { get; set; }
        
        [Required]
        [EnumDataType(typeof(Day))]
        public Day Day { get; set; }

        [Required]
        [Column(TypeName = "TIME")]
        [DataType(DataType.Time)]
        public DateTime OpenHour { get; set; }

        [Required]
        [Column(TypeName = "TIME")]
        [DataType(DataType.Time)]
        public DateTime CloseHour { get; set; }
        
        [Required]
        public int CenterId { get; set; }
        public VaccinationCenter Center { get; set; }
    }
}
