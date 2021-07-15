using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationManager.Models.Vaccin;

namespace VaccinationManager.Models
{
    public class OutLog
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        [DataType(DataType.DateTime)]
        public DateTime OutDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int VaccinLotId { get; set; }
        public VaccinLot VaccinLot { get; set; }
    }
}
