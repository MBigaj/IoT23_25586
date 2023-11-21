using System.CodeDom;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Objects.DataClasses;

namespace lab3.Functions
{
    public class DatabasePersonService : PersonService
    {
        private readonly PersonDb db;

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

            this.db.Person.Add(entity);
            this.db.SaveChanges();

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