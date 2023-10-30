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
        var group = endpoints.MapGroup("/v1/sales/")
            .WithTags("Sales");
        
        group.MapPost("/", SalesEndpoints.HandleCreateOrder)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status201Created)
            .WithName("CreateSalesOrder");
        
        group.MapGet("/", SalesEndpoints.HandleGetOrders)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .WithName("GetSalesOrders");
        
        return endpoints;
    }
}