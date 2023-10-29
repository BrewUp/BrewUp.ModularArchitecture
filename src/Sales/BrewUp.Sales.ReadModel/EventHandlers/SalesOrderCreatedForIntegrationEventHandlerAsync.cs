using BrewUp.Sales.Messages.Events;
using BrewUp.Sales.ReadModel.Services;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Messages;
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
        BeersForSaleCommitted beersForSaleCommitted = new(new OrderId(@event.SalesOrderId.Value),
            new OrderNumber(@event.SalesOrderNumber.Value),
            @event.Rows.Select(x => new BeerCommittedRow(x.BeerId.Value, x.BeerName.Value, x.Quantity)));

        await _eventBus.PublishAsync(beersForSaleCommitted, cancellationToken);
    }
}