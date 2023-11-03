using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages;

public sealed class BeersForSalesOrderAvailable : IntegrationEvent
{
    public readonly OrderId OrderId;
    public readonly IEnumerable<BrewedRow> Rows;
    
    public BeersForSalesOrderAvailable(OrderId aggregateId, IEnumerable<BrewedRow> rows) : base(aggregateId)
    {
        OrderId = aggregateId;
        Rows = rows;
    }
}