using BrewUp.Shared.ReadModel;
using BrewUp.Warehouses.Facade.Validators;
using BrewUp.Warehouses.ReadModel.Entities;
using BrewUp.Warehouses.ReadModel.Queries;
using BrewUp.Warehouses.ReadModel.Services;
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
        services.AddScoped<IBeerService, BeerService>();
        services.AddScoped<IQueries<Beer>, BeerQueries>();

        return services;
    }
}