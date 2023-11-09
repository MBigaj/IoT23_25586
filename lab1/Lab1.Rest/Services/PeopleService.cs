using Lab1.DTO;

namespace Lab1.Rest
{
    public interface PeopleService
    {
        IEnumerable<Person> GetPeople();
    }
}