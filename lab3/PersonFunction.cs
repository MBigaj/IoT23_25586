using System.Net;
using System.Text.Json;
using Azure;
using lab3.Functions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using static lab3.Functions.Person;

namespace lab3.Functions
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
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "post", "get", "put", "delete")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            
            StreamReader reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);

            switch (req.Method)
            {
                case "POST":
                    var jsonPost = reader.ReadToEnd();
                    var personPost = JsonSerializer.Deserialize<Person>(jsonPost);
                    var resPost = personService.Add(personPost.firstName, personPost.lastName);
                    response.WriteAsJsonAsync(resPost);
                    break;
                case "PUT":
                    var jsonPut = reader.ReadToEnd();
                    var personPut = JsonSerializer.Deserialize<Person>(jsonPut);
                    var resPut = personService.Update(personPut);
                    response.WriteAsJsonAsync(resPut);
                    break;
                case "GET":
                    var peopleGet = personService.Get();
                    response.WriteAsJsonAsync(peopleGet);
                    break;
                case "DELETE":
                    var jsonDel = reader.ReadToEnd();
                    var personDel = JsonSerializer.Deserialize<Person>(jsonDel);
                    var idDel = personDel.id;
                    personService.Delete(idDel);
                    response.WriteAsJsonAsync(idDel + " DELETED");
                    break;
            }

            return response;
        }
    }
}
