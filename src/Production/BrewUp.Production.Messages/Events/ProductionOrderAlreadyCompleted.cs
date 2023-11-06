using BrewUp.Shared.DomainIds;
using Muflone.Messages.Events;

namespace BrewUp.Production.Messages.Events;

public sealed class ProductionOrderAlreadyCompleted : DomainEvent
{
    public readonly ProductionOrderId ProductionOrderId;
    
    public ProductionOrderAlreadyCompleted(ProductionOrderId aggregateId) : base(aggregateId)
    {
        ProductionOrderId = aggregateId;
    }
}