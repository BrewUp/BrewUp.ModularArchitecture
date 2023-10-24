using BrewUp.Infrastructures;
using BrewUp.Infrastructures.MongoDb;
using BrewUp.Infrastructures.RabbitMq;
using BrewUp.Sales.Facade;

namespace BrewUp.Rest.Modules;

public sealed class InfrastructureModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure(builder.Configuration.GetSection("BrewUp:MongoDb").Get<MongoDbSettings>()!,
            builder.Configuration.GetSection("BrewUp:EventStore").Get<EventStoreSettings>()!);
        
        builder.Services.AddSalesInfrastructure(builder.Configuration.GetSection("BrewUp:RabbitMQ")
            .Get<RabbitMqSettings>()!);
        
        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints;
}