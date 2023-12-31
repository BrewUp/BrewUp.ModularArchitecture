﻿using BrewUp.Infrastructures;
using BrewUp.Infrastructures.MongoDb;
using BrewUp.Infrastructures.RabbitMq;
using BrewUp.Production.Facade;
using BrewUp.Sales.Facade;
using BrewUp.Warehouses.Facade;

namespace BrewUp.Rest.Modules;

public sealed class InfrastructureModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 10;
    
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure(builder.Configuration.GetSection("BrewUp:MongoDb").Get<MongoDbSettings>()!,
            builder.Configuration.GetSection("BrewUp:EventStore").Get<EventStoreSettings>()!);
        
        builder.Services.AddSalesInfrastructure(builder.Configuration.GetSection("BrewUp:RabbitMQ")
            .Get<RabbitMqSettings>()!);
        builder.Services.AddWarehousesInfrastructure(builder.Configuration.GetSection("BrewUp:RabbitMQ")
            .Get<RabbitMqSettings>()!);
        builder.Services.AddProductionInfrastructure(builder.Configuration.GetSection("BrewUp:RabbitMQ")
            .Get<RabbitMqSettings>()!);
        
        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints;
}