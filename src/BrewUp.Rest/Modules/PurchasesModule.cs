using BrewUp.Purchases.Facade;
using BrewUp.Purchases.Facade.Endpoints;

namespace BrewUp.Rest.Modules;

public sealed class PurchasesModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddPurchases();
        
        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/v1/purchases/")
            .WithTags("Purchases");
        
        group.MapPost("/", PurchasesEndpoints.HandleCreateOrder)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status201Created)
            .WithName("CreatePurchasesOrder");
        
        group.MapGet("/", PurchasesEndpoints.HandleGetOrders)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status201Created)
            .WithName("GetPurchasesOrders");
        
        return endpoints;
    }
}