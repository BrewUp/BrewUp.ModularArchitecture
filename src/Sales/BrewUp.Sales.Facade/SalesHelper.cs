using BrewUp.Infrastructures.RabbitMq;
using BrewUp.Sales.Facade.Validators;
using BrewUp.Sales.Infrastructures.RabbitMq;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Sales.Facade;

public static class SalesHelper
{
    public static IServiceCollection AddSales(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<SalesOrderValidator>();
        services.AddSingleton<ValidationHandler>();
        
        services.AddScoped<ISalesFacade, SalesFacade>();

        return services;
    }
    
    public static IServiceCollection AddSalesInfrastructure(this IServiceCollection services,
        RabbitMqSettings rabbitMqSettings)
    {
        services.AddRabbitMq(rabbitMqSettings);
        
        return services;
    }
}