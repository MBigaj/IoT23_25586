using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using lab3.Services;
using lab3.Database;

namespace lab3.Functions
{
    public class AddressFunction
    {
        private readonly ILogger _logger;
        private readonly AddressService addressService;

        public AddressFunction(ILoggerFactory loggerFactory, AddressService addressService)
        {
            _logger = loggerFactory.CreateLogger<AddressFunction>();
            this.addressService = addressService;
        }

        [Function("AddressFunction")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "post", "get", "put", "delete")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            
            StreamReader reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);

            switch (req.Method)
            {
                case "POST":
                    var jsonPost = reader.ReadToEnd();
                    var addressPost = JsonSerializer.Deserialize<Address>(jsonPost);
                    var resPost = addressService.AddAddress(addressPost);
                    response.WriteAsJsonAsync(resPost);
                    break;
                case "PUT":
                    var jsonPut = reader.ReadToEnd();
                    var addressPut = JsonSerializer.Deserialize<Address>(jsonPut);
                    var resPut = addressService.Update(addressPut);
                    response.WriteAsJsonAsync(resPut);
                    break;
                case "GET":
                    var addressesGet = addressService.GetAddresses();
                    response.WriteAsJsonAsync(addressesGet);
                    break;
                case "DELETE":
                    var jsonDel = reader.ReadToEnd();
                    var addressDel = JsonSerializer.Deserialize<Address>(jsonDel);
                    var idDel = addressDel.id;
                    addressService.Delete(idDel);
                    response.WriteAsJsonAsync(idDel + " DELETED");
                    break;
            }

            return response;
        }
    }
}
