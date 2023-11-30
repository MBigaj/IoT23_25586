namespace lab3.Database
{
    public class Address
    {
        public int id { get; set; }
        public string city { get; set ;}
        public string streetName { get; set ;}

        public List<Person> People { get; set; }
    }
}