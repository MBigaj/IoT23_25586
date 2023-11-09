using Lab1.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Rest
{
    [Route("[people]")]
    class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> logger;
        private readonly PeopleService peopleService;

        public PeopleController(ILogger<PeopleController> logger, PeopleService peopleService)
        {
            this.logger = logger;
            this.peopleService = peopleService;
        }

        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            return this.peopleService.GetPeople();
        }
    }
}