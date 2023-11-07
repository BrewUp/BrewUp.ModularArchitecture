using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class CreatePurchaseOrder : Command
{
    public readonly PurchaseOrderId PurchaseOrderId;
    public readonly PurchaseOrderNumber PurchaseOrderNumber;
    
    public readonly SupplierId SupplierId;
    public readonly OrderDate OrderDate;
    
    public readonly IEnumerable<PurchaseOrderRow> Rows;
    
    public CreatePurchaseOrder(PurchaseOrderId aggregateId, Guid commitId, PurchaseOrderNumber purchaseOrderNumber,
        SupplierId supplierId, OrderDate orderDate, IEnumerable<PurchaseOrderRow> rows) : base(aggregateId, commitId)
    {
        PurchaseOrderId = aggregateId;
        PurchaseOrderNumber = purchaseOrderNumber;

        SupplierId = supplierId;
        OrderDate = orderDate;
        
        Rows = rows;
    }
}