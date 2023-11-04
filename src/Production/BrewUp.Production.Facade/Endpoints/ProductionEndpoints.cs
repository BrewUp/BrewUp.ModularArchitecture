using Microsoft.AspNetCore.Http;

namespace BrewUp.Production.Facade.Endpoints;

public static class ProductionEndpoints
{
    public static Task<IResult> HandleCompleteOrder(
        Guid productionOrderId,
        IProductionFacade productionFacade,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(Results.NoContent());
    }
    
    public static async Task<IResult> HandleGetProductionOrders(
        IProductionFacade productionFacade,
        CancellationToken cancellationToken)
    {
        var orders = await productionFacade.GetProductionOrdersAsync(cancellationToken);

        return Results.Ok(orders.Results);
    }
}