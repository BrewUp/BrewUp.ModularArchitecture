using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class BeersForSaleRequested : IntegrationEvent
{
    public readonly OrderId OrderId;
    public readonly IEnumerable<BeerCommittedRow> Rows;

    public BeersForSaleRequested(OrderId aggregateId, Guid correlationId, IEnumerable<BeerCommittedRow> rows) : base(
        aggregateId, correlationId)
    {
        OrderId = aggregateId;
        Rows = rows;
    }
}