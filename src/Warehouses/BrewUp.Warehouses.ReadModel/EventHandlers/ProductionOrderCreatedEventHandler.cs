using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Warehouses.ReadModel.EventHandlers;

public sealed class ProductionOrderCreatedEventHandler : DomainEventHandlerAsync<ProductionOrderCreated>
{
    private readonly IProductionOrderService _productionOrderService;
    
    public ProductionOrderCreatedEventHandler(ILoggerFactory loggerFactory,
        IProductionOrderService productionOrderService) : base(loggerFactory)
    {
        _productionOrderService = productionOrderService;
    }

    public override async Task HandleAsync(ProductionOrderCreated @event, CancellationToken cancellationToken = new())
    {
        await _productionOrderService.CreateProductionOrderAsync(@event.ProductionOrderId, @event.ProductionOrderNumber,
            @event.OrderDate, @event.Rows, cancellationToken);
    }
}