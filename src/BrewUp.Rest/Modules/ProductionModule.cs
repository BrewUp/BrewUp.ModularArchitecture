using BrewUp.Production.Facade;
using BrewUp.Production.Facade.Endpoints;

namespace BrewUp.Rest.Modules;

public class ProductionModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddProduction();
        
        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/v1/production/")
            .WithTags("Production");
 
        group.MapPut("/complete", ProductionEndpoints.HandleCompleteOrder)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status204NoContent)
            .WithName("CompleteProductionOrder");
        
        group.MapGet("/", ProductionEndpoints.HandleGetProductionOrders)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .WithName("GetProductionOrders");
        
        return endpoints;
    }
}