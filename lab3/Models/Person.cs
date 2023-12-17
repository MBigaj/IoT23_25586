namespace lab3.Database
{
    public class Person
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int addressId { get; set; }
        public Address address { get; set; }
    }
}