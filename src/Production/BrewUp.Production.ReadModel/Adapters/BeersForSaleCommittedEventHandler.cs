using BrewUp.Production.Messages.Commands;
using BrewUp.Production.SharedKernel.DomainIds;
using BrewUp.Production.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Messages;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;

namespace BrewUp.Production.ReadModel.Adapters;

public sealed class BeersForSaleCommittedEventHandler : IntegrationEventHandlerAsync<BeersForSaleCommitted>
{
    private readonly IServiceBus _serviceBus;
    
    public BeersForSaleCommittedEventHandler(ILoggerFactory loggerFactory,
        IServiceBus serviceBus) : base(loggerFactory)
    {
        _serviceBus = serviceBus;
    }

    public override async Task HandleAsync(BeersForSaleCommitted @event, CancellationToken cancellationToken = new ())
    {
        CreateProductionOrder createProductionOrder = new(new ProductionOrderId(@event.OrderId.Value),
            new ProductionOrderNumber(@event.OrderNumber.Value),
            new OrderDate(DateTime.UtcNow),
            @event.Rows.Select(x =>
                new ProductionOrderRow(new BeerId(x.BeerId), new BeerName(x.BeerName), x.Quantity)));

        await _serviceBus.SendAsync(createProductionOrder, cancellationToken);
    }
}