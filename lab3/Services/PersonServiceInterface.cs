using lab3.Database;

namespace lab3
{
    public interface PersonServiceInterface
    {
        Person FindById(int id);
        IEnumerable<Person> GetPeople();
        Person AddPerson(Person person);
    }
}