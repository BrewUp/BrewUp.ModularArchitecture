using BrewUp.Production.SharedKernel.DomainIds;
using BrewUp.Production.SharedKernel.Dtos;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Production.Messages.Events;

public sealed class ProductionOrderCreated : DomainEvent
{
    public readonly ProductionOrderId ProductionOrderId;
    public readonly ProductionOrderNumber ProductionOrderNumber;
    
    public readonly OrderDate OrderDate;
    
    public readonly IEnumerable<ProductionOrderRow> Rows;
    
    public ProductionOrderCreated(ProductionOrderId aggregateId, ProductionOrderNumber productionOrderNumber,
        OrderDate orderDate, IEnumerable<ProductionOrderRow> rows) : base(aggregateId)
    {
        ProductionOrderId = aggregateId;
        ProductionOrderNumber = productionOrderNumber;

        OrderDate = orderDate;
        
        Rows = rows;
    }
}