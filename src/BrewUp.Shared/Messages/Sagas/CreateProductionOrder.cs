using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class CreateProductionOrder : Command
{
    public readonly ProductionOrderId ProductionOrderId;
    public readonly ProductionOrderNumber ProductionOrderNumber;
    
    public readonly OrderDate OrderDate;
    
    public readonly IEnumerable<ProductionOrderRow> Rows;

    public CreateProductionOrder(ProductionOrderId aggregateId, Guid correlationId,
        ProductionOrderNumber productionOrderNumber, OrderDate orderDate, IEnumerable<ProductionOrderRow> rows) : base(
        aggregateId, correlationId)
    {
        ProductionOrderId = aggregateId;
        ProductionOrderNumber = productionOrderNumber;

        OrderDate = orderDate;
        
        Rows = rows;
    }
}