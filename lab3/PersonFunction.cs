using System.Net;
using System.Text.Json;
using Azure;
using lab3.Functions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using static lab3.Functions.PersonService;

namespace Lab3.Functions
{
    public class PersonFunction
    {
        private readonly ILogger _logger;
        private readonly PersonService personService;

        public PersonFunction(ILoggerFactory loggerFactory, PersonService personService)
        {
            _logger = loggerFactory.CreateLogger<PersonFunction>();
            this.personService = personService;
        }

        [Function("PersonFunction")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            switch (req.Method)
            {
                case "POST":
                    StreamReader reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var json = reader.ReadToEnd();
                    var person = JsonSerializer.Deserialize<Person>(json);
                    var res = personService.Add(person.firstName, person.lastName);
                    response.WriteAsJsonAsync(res);
                    break;
                case "PUT":
                    break;
                case "GET":
                    var people = personService.Get();
                    response.WriteAsJsonAsync(people);
                    break;
                case "DELETE":
                    break;

            }

            return response;
        }
    }
}
