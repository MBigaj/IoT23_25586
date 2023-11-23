using lab3.Database;

namespace lab3.Services
{
    public class PersonService
    {
        private List<Person> people { get; } = new List<Person>();

        public Person AddPerson(Person personData)
        {
            var person = new Person {
                firstName = personData.firstName,
                lastName = personData.lastName,
                id = people.Count + 1
            };

            people.Add(person);
            return person;
        }

        public Person Update(Person personData)
        {
            var person = people.First(w => w.id == personData.id);
            person.firstName = personData.firstName;
            person.lastName = personData.lastName;

            return person;
        }

        public void Delete(int id)
        {
            var person = people.First(w => w.id == id);
            people.Remove(person);
        }

        public Person FindById(int id)
        {
            return people.First(w => w.id == id);
        }

        public IEnumerable<Person> GetPeople()
        {
            return people;
        }
    }
}