using BrewUp.Sales.Messages.Events;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Messages.Sagas;
using Microsoft.Extensions.Logging;
using Muflone;

namespace BrewUp.Sales.ReadModel.EventHandlers;

public sealed class SalesOrderCreatedForIntegrationEventHandlerAsync : DomainEventHandlerBase<SalesOrderCreated>
{
    private readonly IEventBus _eventBus;
    
    public SalesOrderCreatedForIntegrationEventHandlerAsync(ILoggerFactory loggerFactory,
        IEventBus eventBus) : base(loggerFactory)
    {
        _eventBus = eventBus;
    }

    public override async Task HandleAsync(SalesOrderCreated @event, CancellationToken cancellationToken = new ())
    {
        BeersForSaleRequested beersForSaleRequested = new(new OrderId(@event.SalesOrderId.Value),
            Guid.NewGuid(), 
            @event.Rows.Select(x => new BeerCommittedRow(x.BeerId.Value, x.BeerName.Value, x.Quantity)));
        await _eventBus.PublishAsync(beersForSaleRequested, cancellationToken);
    }
}