using BrewUp.Production.SharedKernel.DomainIds;
using Muflone.Messages.Commands;

namespace BrewUp.Production.Messages.Commands;

public sealed class CompleteProductionOrder : Command
{
    public readonly ProductionOrderId ProductionOrderId;
    
    public CompleteProductionOrder(ProductionOrderId aggregateId) : base(aggregateId)
    {
        ProductionOrderId = aggregateId;
    }
}