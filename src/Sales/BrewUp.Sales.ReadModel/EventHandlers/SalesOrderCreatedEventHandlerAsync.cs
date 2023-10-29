using BrewUp.Sales.Messages.Events;
using BrewUp.Sales.ReadModel.Services;
using BrewUp.Shared.Dtos;
using Microsoft.Extensions.Logging;

namespace BrewUp.Sales.ReadModel.EventHandlers;

public sealed class SalesOrderCreatedEventHandlerAsync : DomainEventHandlerBase<SalesOrderCreated>
{
    private readonly ISalesOrderService _salesOrderService;
    
    public SalesOrderCreatedEventHandlerAsync(ILoggerFactory loggerFactory,
        ISalesOrderService salesOrderService) : base(loggerFactory)
    {
        _salesOrderService = salesOrderService;
    }

    public override async Task HandleAsync(SalesOrderCreated @event, CancellationToken cancellationToken = new ())
    {
        try
        {
            await _salesOrderService.CreateSalesOrderAsync(@event.SalesOrderId, @event.SalesOrderNumber, @event.PubId,
                @event.PubName, @event.OrderDate, @event.Rows, cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error handling sales order created event");
            throw;
        }
    }
}