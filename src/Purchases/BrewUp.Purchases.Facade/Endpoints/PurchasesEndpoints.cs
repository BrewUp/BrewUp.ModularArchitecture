using BrewUp.Purchases.Facade.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BrewUp.Purchases.Facade.Endpoints;

public static class PurchasesEndpoints
{
    public static async Task<IResult> HandleCreateOrder(
        IPurchasesFacade purchasesFacade,
        IValidator<BindingModels.PurchasesOrderJson> validator,
        ValidationHandler validationHandler,
        BindingModels.PurchasesOrderJson body,
        CancellationToken cancellationToken)
    {
        await validationHandler.ValidateAsync(validator, body);
        if (!validationHandler.IsValid)
            return Results.BadRequest(validationHandler.Errors);

        var orderId = await purchasesFacade.CreateOrderAsync(body, cancellationToken);

        return Results.Created($"/v1/purchases/orders/{orderId}", orderId);
    }
    
    public static async Task<IResult> HandleGetOrders(
        IPurchasesFacade purchasesFacade,
        CancellationToken cancellationToken)
    {
        var orders = await purchasesFacade.GetOrdersAsync(cancellationToken);

        return Results.Ok(orders);
    }
}