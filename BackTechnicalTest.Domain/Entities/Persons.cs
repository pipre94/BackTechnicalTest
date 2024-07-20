namespace BackTechnicalTest.Domain.Entities
{
    public class Persons
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string IdentificationType { get; set; }
        public DateTime CreationDate { get; set; }
        public string FullIdentification { get; set; }
        public string FullName { get; set; }
    }
}
