using System.Collections.Immutable;
using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Sales.Messages.Events;

public sealed class SalesOrderCompleted : DomainEvent
{
    public readonly SalesOrderId SalesOrderId;
    public readonly IImmutableList<SalesOrderRowDto> Rows;
    
    public SalesOrderCompleted(SalesOrderId aggregateId, IEnumerable<SalesOrderRowDto> rows) : base(aggregateId)
    {
        SalesOrderId = aggregateId;
        Rows = rows.ToImmutableList();
    }
}