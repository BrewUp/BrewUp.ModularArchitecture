using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages;

public sealed class BeersForSaleCommitted : IntegrationEvent
{
    public readonly OrderId OrderId;
    public readonly OrderNumber OrderNumber;
    
    public readonly IEnumerable<BeerCommittedRow> Rows;
    
    public BeersForSaleCommitted(OrderId aggregateId, OrderNumber orderNumber, IEnumerable<BeerCommittedRow> rows) : base(aggregateId)
    {
        OrderId = aggregateId;
        OrderNumber = orderNumber;
        
        Rows = rows;
    }
}