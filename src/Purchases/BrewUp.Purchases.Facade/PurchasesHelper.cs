using BrewUp.Infrastructures.RabbitMq;
using BrewUp.Purchases.Facade.Validators;
using BrewUp.Purchases.Infrastructures.RabbitMq;
using BrewUp.Purchases.ReadModel.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Purchases.Facade;

public static class PurchasesHelper
{
    public static IServiceCollection AddPurchases(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<PurchasesOrderValidator>();
        services.AddSingleton<ValidationHandler>();
        
        services.AddScoped<IPurchasesFacade, PurchasesFacade>();
        services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();

        return services;
    }

    public static IServiceCollection AddPurchasesInfrastructure(this IServiceCollection services, RabbitMqSettings rabbitMqSettings)
    {
        services.AddRabbitMqForPurchasesModule(rabbitMqSettings);

        return services;
    }
}