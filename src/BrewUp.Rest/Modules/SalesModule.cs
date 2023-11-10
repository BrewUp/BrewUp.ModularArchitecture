using BrewUp.Sales.Facade;
using BrewUp.Sales.Facade.Endpoints;

namespace BrewUp.Rest.Modules;

public sealed class SalesModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddSales();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapSalesEndpoints();
    }
}