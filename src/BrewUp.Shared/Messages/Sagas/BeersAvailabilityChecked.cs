using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class BeerAvailabilityChecked : DomainEvent
{
    public readonly BeerId BeerId;
    public readonly Availability Availability;
    
    public BeerAvailabilityChecked(BeerId aggregateId, Guid correlationId, Availability availability) : base(aggregateId, correlationId)
    {
        BeerId = aggregateId;
        Availability = availability;
    }
}