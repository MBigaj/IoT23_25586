using lab3.Functions;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<PersonService>();

        var connectionString = services.Configuration.GetConnectionString("Server=tcp:iot-server-cdv.database.windows.net,1433;Initial Catalog=iot_database;Persist Security Info=False;User ID=nick;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        services.UseSqlServer(connectionString);

        services.AddTransient<PersonService, DatabasePersonService>();
    })
    .Build();

host.Run();
