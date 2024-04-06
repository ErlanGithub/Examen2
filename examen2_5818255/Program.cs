using examen2_5818255;
using examen2_5818255.implementacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables()
           .Build();
        services.AddDbContext<Contexto>(options => options.UseSqlServer(
                    configuration.GetConnectionString("cadenaConexion")));
        services.AddScoped<IInterfaz, implementacion>();
    })
    .Build();

host.Run();