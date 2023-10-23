using BrewUp.Warehouses.Facade.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BrewUp.Warehouses.Facade.Endpoints;

public static class WarehousesEndpoint
{
    public static async Task<IResult> HandleCreateWarehouse(
        IWarehousesFacade warehousesFacade,
        IValidator<BindingModels.WarehouseJson> validator,
        ValidationHandler validationHandler,
        BindingModels.WarehouseJson body,
        CancellationToken cancellationToken)
    {
        await validationHandler.ValidateAsync(validator, body);
        if (!validationHandler.IsValid)
            return Results.BadRequest(validationHandler.Errors);

        var orderId = await warehousesFacade.CreateWarehouseAsync(body, cancellationToken);

        return Results.Created($"/v1/Sales/Orders/{orderId}", orderId);
    }
    
    public static async Task<IResult> HandleGetWarehouses(
        IWarehousesFacade warehousesFacade,
        CancellationToken cancellationToken)
    {
        var warehouses = await warehousesFacade.GetWarehousesAsync(cancellationToken);

        return Results.Ok(warehouses);
    }
}