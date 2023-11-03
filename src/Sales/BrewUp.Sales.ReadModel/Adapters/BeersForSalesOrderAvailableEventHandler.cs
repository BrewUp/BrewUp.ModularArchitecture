using BrewUp.Sales.Messages.Commands;
using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Shared.Messages;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;

namespace BrewUp.Sales.ReadModel.Adapters;

public sealed class BeersForSalesOrderAvailableEventHandler : IntegrationEventHandlerAsync<BeersForSalesOrderAvailable>
{
    private readonly IServiceBus _serviceBus;
    
    public BeersForSalesOrderAvailableEventHandler(ILoggerFactory loggerFactory, IServiceBus serviceBus) : base(loggerFactory)
    {
        _serviceBus = serviceBus ?? throw new ArgumentNullException(nameof(serviceBus));
    }

    public override async Task HandleAsync(BeersForSalesOrderAvailable @event, CancellationToken cancellationToken = new ())
    {
        CompleteSalesOrder completeSalesOrder = new(new SalesOrderId(@event.OrderId.Value), @event.Rows);

        await _serviceBus.SendAsync(completeSalesOrder, cancellationToken);
    }
}