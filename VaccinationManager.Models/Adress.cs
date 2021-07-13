namespace VaccinationManager.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public District District { get; set; }
    }
}