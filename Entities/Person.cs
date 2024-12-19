namespace Entities
{
    public class Person
    {
        public int IdPerson { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
    }
}
