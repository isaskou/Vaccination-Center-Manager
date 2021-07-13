namespace VaccinationManager.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public Grade Grade { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}