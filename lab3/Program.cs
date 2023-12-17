using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using lab3.Database;
using lab3.Functions;
using lab3.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<DatabasePersonService>();
        services.AddSingleton<DatabaseAddressService>();
        services.AddDbContext<PersonDb>(options => {
            options.UseSqlServer("Server=tcp:lab3-iot.database.windows.net,1433;Initial Catalog=iot-database;Persist Security Info=False;User ID=nick;Password=Superdatabase1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        });
    })
    .Build();

host.Run();
