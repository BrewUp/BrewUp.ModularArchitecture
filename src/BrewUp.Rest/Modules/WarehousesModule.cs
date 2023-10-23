using BrewUp.Warehouses.Facade;
using BrewUp.Warehouses.Facade.Endpoints;

namespace BrewUp.Rest.Modules;

public sealed class WarehousesModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddWarehouses();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/v1/warehouses/")
            .WithTags("Warehouses");
        
        group.MapPost("/", WarehousesEndpoint.HandleCreateWarehouse)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status201Created)
            .WithName("CreateWarehouse");
        
        group.MapGet("/", WarehousesEndpoint.HandleGetWarehouses)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status201Created)
            .WithName("GetWarehouses");

        return endpoints;
    }
}