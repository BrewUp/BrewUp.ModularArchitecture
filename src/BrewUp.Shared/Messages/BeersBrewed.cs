using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages;

public sealed class BeersBrewed : IntegrationEvent
{
    public readonly OrderId OrderId;
    public readonly IEnumerable<BrewedRow> Rows;
    
    public BeersBrewed(OrderId aggregateId, IEnumerable<BrewedRow> rows) : base(aggregateId)
    {
        OrderId = aggregateId;
        Rows = rows;
    }
}