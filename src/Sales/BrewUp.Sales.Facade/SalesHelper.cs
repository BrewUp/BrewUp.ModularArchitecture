using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Sales.Facade;

public static class SalesHelper
{
    public static IServiceCollection AddSales(this IServiceCollection services)
    {
        services.AddScoped<ISalesFacade, SalesFacade>();

        return services;
    }
}