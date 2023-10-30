using BrewUp.Production.Messages.Events;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Messages;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;

namespace BrewUp.Production.ReadModel.EventHandlers;

public sealed class ProductionOrderCompletedForIntegrationEventHandler : DomainEventHandlerAsync<ProductionOrderCompleted>
{
    private readonly IEventBus _eventBus;
    
    public ProductionOrderCompletedForIntegrationEventHandler(ILoggerFactory loggerFactory, IEventBus eventBus) : base(loggerFactory)
    {
        _eventBus = eventBus;
    }

    public override async Task HandleAsync(ProductionOrderCompleted @event, CancellationToken cancellationToken = new ())
    {
        BeersBrewed beersBrewed = new (new OrderId(@event.ProductionOrderId.Value),
            @event.Rows.Select(r => new BrewedRow(r.BeerId, r.BeerName, r.Quantity)));
        await _eventBus.PublishAsync(beersBrewed, cancellationToken);
    }
}