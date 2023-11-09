using Lab1.DTO;

namespace Lab1.Rest.Services
{
    public class MockPeopleService : PeopleService
    {
        public IEnumerable<Person> GetPeople()
        {
            var peopleList = new List<Person>();

            for (int i = 0; i < 10; i++)
            {
                peopleList.Add(new Person{
                    FirstName = $"Person first name - {i}",
                    LastName = $"Person first name - {i}",
                    Id = i + 1
                });
            }

            return peopleList;
        }
    }
}