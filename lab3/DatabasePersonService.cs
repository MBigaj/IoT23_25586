using lab3.Database;

namespace lab3.Services
{
    public class DatabasePersonService : PersonService
    {
        private PersonDb db;

        public DatabasePersonService(PersonDb db)
        {
            this.db = db;
        }

        public class AddPerson(Person person)
        {
            var entity = new Person
            {
                firstName = person.firstName,
                lastName = person.lastName
            };

            db.Person.AddPerson(entity);
            db.SaveChanges();

            person.id = entity.id;
            return person;
        }

        public IEnumerable<Person> GetPeople()
        {
            var peopleList = db.Person.Select(s => new Person
            {
                id = s.id,
                firstName = s.firstName,
                lastName = s.lastName
            });

            return peopleList;
        }
    }
}