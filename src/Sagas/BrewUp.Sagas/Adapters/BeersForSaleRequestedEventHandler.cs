using BrewUp.Sagas.Messages.Commands;
using BrewUp.Shared.Messages.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;

namespace BrewUp.Sagas.Adapters;

public sealed class BeersForSaleRequestedEventHandler : IntegrationEventHandlerAsync<BeersForSaleRequested>
{
    private readonly IServiceBus _serviceBus;
    
    public BeersForSaleRequestedEventHandler(ILoggerFactory loggerFactory, IServiceBus serviceBus) : base(loggerFactory)
    {
        _serviceBus = serviceBus;
    }

    public override async Task HandleAsync(BeersForSaleRequested @event, CancellationToken cancellationToken = new ())
    {
        var correlationId =
            new Guid(@event.UserProperties.FirstOrDefault(u => u.Key.Equals("CorrelationId")).Value.ToString()!);

        StartSalesOrderSaga startSalesOrderSaga = new(@event.OrderId, correlationId, @event.Rows);
        await _serviceBus.SendAsync(startSalesOrderSaga, cancellationToken);
    }
}