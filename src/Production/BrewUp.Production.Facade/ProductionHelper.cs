using BrewUp.Production.ReadModel.Entities;
using BrewUp.Production.ReadModel.Queries;
using BrewUp.Production.ReadModel.Services;
using BrewUp.Shared.ReadModel;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Production.Facade;

public static class ProductionHelper
{
    public static IServiceCollection AddProduction(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        // services.AddValidatorsFromAssemblyContaining<WarehouseValidator>();
        // services.AddSingleton<ValidationHandler>();
        
        services.AddScoped<IProductionFacade, ProductionFacade>();
        services.AddScoped<IProductionOrderService, ProductionOrderService>();
        services.AddScoped<IQueries<ProductionOrder>, ProductionOrderQueries>();

        return services;
    }
}