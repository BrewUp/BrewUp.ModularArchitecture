using BrewUp.Shared.Dtos;
using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Warehouses.Messages.Commands;

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