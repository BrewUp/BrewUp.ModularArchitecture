using BrewUp.Purchases.Messages.Events;
using BrewUp.Purchases.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Purchases.ReadModel.EventHandlers;

public sealed class PurchaseOrderCreatedEventHandler : DomainEventHandlerAsync<PurchaseOrderCreated>
{
    public readonly IPurchaseOrderService _purchaseOrderService;
    
    public PurchaseOrderCreatedEventHandler(ILoggerFactory loggerFactory, IPurchaseOrderService purchaseOrderService) : base(loggerFactory)
    {
        _purchaseOrderService = purchaseOrderService;
    }

    public override async Task HandleAsync(PurchaseOrderCreated @event, CancellationToken cancellationToken = new ())
    {
        await _purchaseOrderService.CreatePurchaseOrderAsync(@event.PurchaseOrderId, @event.OrderDate, @event.Rows,
            @event.SupplierId, cancellationToken);
    }
}