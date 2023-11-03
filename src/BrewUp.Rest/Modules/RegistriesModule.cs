using BrewUp.Registries.Facade;
using BrewUp.Registries.Facade.Endpoints;

namespace BrewUp.Rest.Modules;

public class RegistriesModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;
    
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddRegistries();
        
        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/v1/registries/")
            .WithTags("Registries");
        
        group.MapPost("/pubs", RegistriesEndpoints.HandleCreatePub)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status201Created)
            .WithName("CreatePub");
        
        group.MapGet("/pubs", RegistriesEndpoints.HandleGetPubs)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .WithName("GetPubs");
        
        group.MapPost("/beers", RegistriesEndpoints.HandleCreateBeer)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status201Created)
            .WithName("CreateBeer");
        
        group.MapGet("/beers", RegistriesEndpoints.HandleGetBeers)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .WithName("GetBeers");
        
        return endpoints;
    }
}