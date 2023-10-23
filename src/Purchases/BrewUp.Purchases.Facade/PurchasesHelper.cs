using BrewUp.Purchases.Facade.Validators;
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

        return services;
    }
}