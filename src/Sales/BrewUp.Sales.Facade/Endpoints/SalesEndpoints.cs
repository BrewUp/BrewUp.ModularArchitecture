using BrewUp.Sales.Facade.Validators;
using BrewUp.Shared.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BrewUp.Sales.Facade.Endpoints;

public static class SalesEndpoints
{
    public static async Task<IResult> HandleCreateOrder(
        ISalesFacade salesFacade,
        IValidator<SalesOrderJson> validator,
        ValidationHandler validationHandler,
        SalesOrderJson body,
        CancellationToken cancellationToken)
    {
        await validationHandler.ValidateAsync(validator, body);
        if (!validationHandler.IsValid)
            return Results.BadRequest(validationHandler.Errors);

        var orderId = await salesFacade.CreateOrderAsync(body, cancellationToken);

        return Results.Created($"/v1/sales/orders/{orderId}", orderId);
    }
    
    public static async Task<IResult> HandleGetOrders(
        ISalesFacade salesFacade,
        CancellationToken cancellationToken)
    {
        var orders = await salesFacade.GetOrdersAsync(cancellationToken);

        return Results.Ok(orders);
    }
}