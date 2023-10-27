using BrewUp.MasterData.Facade.BindingModels;
using BrewUp.MasterData.Facade.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BrewUp.MasterData.Facade.Endpoints;

public static class MasterDataEndpoints
{
    public static async Task<IResult> HandleCreatePub(
        IMasterDataFacade masterDataFacade,
        IValidator<PubModel> validator,
        ValidationHandler validationHandler,
        PubModel body,
        CancellationToken cancellationToken)
    {
        await validationHandler.ValidateAsync(validator, body);
        if (!validationHandler.IsValid)
            return Results.BadRequest(validationHandler.Errors);

        var pubId = await masterDataFacade.CreatePubsAsync(body, cancellationToken);

        return Results.Created($"/v1/masterdata/pubs/{pubId}", pubId);
    }
    
    public static async Task<IResult> HandleGetPubs(
        IMasterDataFacade masterDataFacade,
        CancellationToken cancellationToken)
    {
        var pubs = await masterDataFacade.GetPubsAsync(cancellationToken);

        return Results.Ok(pubs);
    }
}