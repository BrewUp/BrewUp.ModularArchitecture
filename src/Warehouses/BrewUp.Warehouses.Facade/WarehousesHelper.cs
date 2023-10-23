using BrewUp.Warehouses.Facade.Validators;
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

        return services;
    }
}