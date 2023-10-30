using BrewUp.Production.Messages.Events;
using BrewUp.Production.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Production.ReadModel.EventHandlers;

public sealed class ProductionOrderCompletedEventHandler : DomainEventHandlerAsync<ProductionOrderCompleted>
{
    private readonly IProductionOrderService _productionOrderService;
    
    public ProductionOrderCompletedEventHandler(ILoggerFactory loggerFactory, IProductionOrderService productionOrderService) : base(loggerFactory)
    {
        _productionOrderService = productionOrderService;
    }

    public override async Task HandleAsync(ProductionOrderCompleted @event, CancellationToken cancellationToken = new ())
    {
        await _productionOrderService.CompleteProductionOrderAsync(@event.ProductionOrderId, cancellationToken);
    }
}