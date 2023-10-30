using BrewUp.Infrastructures.RabbitMq;
using BrewUp.Shared.ReadModel;
using BrewUp.Warehouses.Facade.Validators;
using BrewUp.Warehouses.Infrastructures.RabbitMq;
using BrewUp.Warehouses.ReadModel.Entities;
using BrewUp.Warehouses.ReadModel.Queries;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Warehouses.Facade;

public static class WarehousesHelper
{
    public static IServiceCollection AddWarehouses(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<WarehouseValidator>();
        services.AddSingleton<ValidationHandler>();
        
        services.AddScoped<IWarehousesFacade, WarehousesFacade>();
        services.AddScoped<IQueries<Beer>, BeerQueries>();

        return services;
    }
    
    public static IServiceCollection AddWarehousesInfrastructure(this IServiceCollection services,
        RabbitMqSettings rabbitMqSettings)
    {
        services.AddRabbitMqForWarehousesModule(rabbitMqSettings);
        
        return services;
    }
}