using System.Collections.Immutable;
using BrewUp.Production.SharedKernel.DomainIds;
using BrewUp.Production.SharedKernel.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Production.Messages.Events;

public sealed class ProductionOrderCompleted : DomainEvent
{
    public readonly ProductionOrderId ProductionOrderId;
    public readonly IImmutableList<ProductionOrderRow> Rows;
    
    public ProductionOrderCompleted(ProductionOrderId aggregateId, IEnumerable<ProductionOrderRow> rows) : base(aggregateId)
    {
        ProductionOrderId = aggregateId;
        Rows = rows.ToImmutableList();
    }
}