namespace Baseball1.Models
{
    public class PersonParameters
    {
        public List<Person> Persons { get; set; } = new List<Person>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
