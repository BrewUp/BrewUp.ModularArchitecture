using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Purchases.Messages.Events;

public sealed class PurchaseOrderCreated : DomainEvent
{
    public readonly PurchaseOrderId PurchaseOrderId;
    public readonly SupplierId SupplierId;
    public readonly OrderDate OrderDate;

    public readonly IEnumerable<PurchaseOrderRow> Rows;

    public PurchaseOrderCreated(PurchaseOrderId aggregateId, Guid correlationId, SupplierId supplierId,
        OrderDate orderDate, IEnumerable<PurchaseOrderRow> rows) : base(aggregateId, correlationId)
    {
        PurchaseOrderId = aggregateId;
        SupplierId = supplierId;
        OrderDate = orderDate;
        
        Rows = rows;
    }
}