using Microsoft.Extensions.Logging;
using lab3.Services;
using lab3.Database;
using Microsoft.AspNetCore.Mvc;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;

namespace lab3.Functions
{   
    [ApiController]
    [Route("person")]
    public class PersonConTroller : ControllerBase
    {
        private readonly ILogger<PersonConTroller> logger;
        private readonly PersonService personService;

        public PersonConTroller(ILogger<PersonConTroller> logger, PersonService personService)
        {
            this.logger = logger;
            this.personService = personService;
        }
        
        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            return personService.GetPeople();
        }

        [HttpPost]
        public Person AddPerson([FromBody] Person person)
        {
            return personService.AddPerson(person);
        }

        [HttpGet("{id}")]
        public Person FindById([FromRoute] int id)
        {
            return personService.FindById(id);
        }
    }
}