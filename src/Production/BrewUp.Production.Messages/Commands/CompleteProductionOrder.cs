using BrewUp.Shared.DomainIds;
using Muflone.Messages.Commands;

namespace BrewUp.Production.Messages.Commands;

public sealed class CompleteProductionOrder : Command
{
    public readonly ProductionOrderId ProductionOrderId;
    
    public CompleteProductionOrder(ProductionOrderId aggregateId, Guid correlationId) : base(aggregateId, correlationId)
    {
        ProductionOrderId = aggregateId;
    }
}