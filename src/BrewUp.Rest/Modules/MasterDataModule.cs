using BrewUp.MasterData.Facade;
using BrewUp.MasterData.Facade.Endpoints;

namespace BrewUp.Rest.Modules;

public class MasterDataModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddMasterData();
        
        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/v1/masterdata/")
            .WithTags("MasterData");
        
        group.MapPost("/pubs", MasterDataEndpoints.HandleCreatePub)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status201Created)
            .WithName("CreatePub");
        
        group.MapGet("/pubs", MasterDataEndpoints.HandleGetPubs)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .WithName("GetPubs");
        
        return endpoints;
    }
}