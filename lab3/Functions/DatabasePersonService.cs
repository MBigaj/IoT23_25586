using lab3.Database;

namespace lab3.Services
{
    public class DatabasePersonService : PersonServiceInterface
    {
        private PersonDb db;

        private DatabaseAddressService databaseAddressService;

        public DatabasePersonService(PersonDb db)
        {
            this.db = db;
        }

        public Person AddPerson(Person person)
        {
            var entity = new Person
            {
                firstName = person.firstName,
                lastName = person.lastName,
                addressId = person.addressId
            };

            this.db.Person.Add(entity);
            this.db.SaveChanges();

            person.id = entity.id;
            return person;
        }

        public Person FindById(int id)
        {
            var person = this.db.Person.First(w => w.id == id);
            return this.MapToDTO(person);
        }

        public IEnumerable<Person> GetPeople()
        {
            var databaseAddressService = new DatabaseAddressService(this.db);

            var people = this.db.Person.Select(s => new Person
            {
                id = s.id,
                firstName = s.firstName,
                lastName = s.lastName,
            });

            return people;
        }

        public Person MapToDTO(Person entity)
        {
            return new Person
            {
                id = entity.id,
                firstName = entity.firstName,
                lastName = entity.lastName
            };
        }
    }
}