using BrewUp.Registries.Facade.BindingModels;
using BrewUp.Registries.Facade.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BrewUp.Registries.Facade.Endpoints;

public static class RegistriesEndpoints
{
    #region Pubs
    public static async Task<IResult> HandleCreatePub(
        IRegistriesFacade registriesFacade,
        IValidator<PubModel> validator,
        ValidationHandler validationHandler,
        PubModel body,
        CancellationToken cancellationToken)
    {
        await validationHandler.ValidateAsync(validator, body);
        if (!validationHandler.IsValid)
            return Results.BadRequest(validationHandler.Errors);

        var pubId = await registriesFacade.CreatePubsAsync(body, cancellationToken);

        return Results.Created($"/v1/registries/pubs/{pubId}", pubId);
    }
    
    public static async Task<IResult> HandleGetPubs(
        IRegistriesFacade registriesFacade,
        CancellationToken cancellationToken)
    {
        var pubs = await registriesFacade.GetPubsAsync(cancellationToken);

        return Results.Ok(pubs.Results);
    }
    #endregion

    #region Beers
    public static async Task<IResult> HandleCreateBeer(
        IRegistriesFacade registriesFacade,
        IValidator<BeerModel> validator,
        ValidationHandler validationHandler,
        BeerModel body,
        CancellationToken cancellationToken)
    {
        await validationHandler.ValidateAsync(validator, body);
        if (!validationHandler.IsValid)
            return Results.BadRequest(validationHandler.Errors);

        var beerId = await registriesFacade.CreateBeerAsync(body, cancellationToken);

        return Results.Created($"/v1/registries/beers/{beerId}", beerId);
    }
    
    public static async Task<IResult> HandleGetBeers(
        IRegistriesFacade registriesFacade,
        CancellationToken cancellationToken)
    {
        var beers = await registriesFacade.GetBeersAsync(cancellationToken);

        return Results.Ok(beers.Results);
    }
    #endregion
}