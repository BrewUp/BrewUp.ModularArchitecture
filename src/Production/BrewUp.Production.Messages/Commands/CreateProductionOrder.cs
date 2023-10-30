using BrewUp.Production.SharedKernel.DomainIds;
using BrewUp.Production.SharedKernel.Dtos;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Production.Messages.Commands;

public sealed class CreateProductionOrder : Command
{
    public readonly ProductionOrderId ProductionOrderId;
    public readonly ProductionOrderNumber ProductionOrderNumber;
    
    public readonly OrderDate OrderDate;
    
    public readonly IEnumerable<ProductionOrderRow> Rows;

    public CreateProductionOrder(ProductionOrderId aggregateId, ProductionOrderNumber productionOrderNumber,
        OrderDate orderDate, IEnumerable<ProductionOrderRow> rows) : base(aggregateId)
    {
        ProductionOrderId = aggregateId;
        ProductionOrderNumber = productionOrderNumber;

        OrderDate = orderDate;
        
        Rows = rows;
    }
}