using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccinationManager.Models
{
    public class InLog
    {
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "DATETIME")]
        [DataType(DataType.DateTime)]
        public DateTime InDate { get; set; }
        
        [Required]
        public int Quantity { get; set; }
    }
}