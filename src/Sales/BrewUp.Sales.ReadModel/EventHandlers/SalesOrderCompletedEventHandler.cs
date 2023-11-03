using BrewUp.Sales.Messages.Events;
using BrewUp.Sales.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Sales.ReadModel.EventHandlers;

public sealed class SalesOrderCompletedEventHandler : DomainEventHandlerAsync<SalesOrderCompleted>
{
    private readonly ISalesOrderService _salesOrderService;
    
    public SalesOrderCompletedEventHandler(ILoggerFactory loggerFactory, ISalesOrderService salesOrderService) : base(loggerFactory)
    {
        _salesOrderService = salesOrderService;
    }

    public override async Task HandleAsync(SalesOrderCompleted @event, CancellationToken cancellationToken = new ())
    {
        await _salesOrderService.CompleteSalesOrderAsync(@event.SalesOrderId, cancellationToken);
    }
}