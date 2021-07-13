namespace VaccinationManager.Models
{
    public class MedicalStaff
    {
        public int Id { get; set; }
        public int InamiCode { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}