namespace lab3.Functions
{
    public class PersonService
    {
        private List<Person> people { get; } = new List<Person>();

        public Person Add(string firstName, string lastName)
        {
            var person = new Person {
                firstName = firstName,
                lastName = lastName,
                id = people.Count + 1
            };

            people.Add(person);
            return person;
        }

        public Person Update(int id, string firstName, string lastName)
        {
            var person = people.First(w => w.id == id);
            person.firstName = firstName;
            person.lastName = lastName;

            return person;
        }

        public void Delete(int id)
        {
            var person = people.First(w => w.id == id);
            people.Remove(person);
        }

        public Person Find(int id)
        {
            return people.First(w => w.id == id);
        }

        public IEnumerable<Person> Get()
        {
            return people;
        }

        public class Person
        {
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
        }
    }
}