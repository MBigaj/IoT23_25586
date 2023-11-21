using Microsoft.Extensions.Logging;

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
        public IEnumerable<Person> AddPerson()
        {
            return personService.AddPerson();
        }
    }
}