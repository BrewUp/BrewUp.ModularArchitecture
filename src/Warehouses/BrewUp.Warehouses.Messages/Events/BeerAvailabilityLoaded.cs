using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Warehouses.Messages.Events;

public sealed class BeerAvailabilityLoaded : DomainEvent
{
    public readonly BeerId BeerId;
    public readonly Availability Availability;
    
    public BeerAvailabilityLoaded(BeerId aggregateId, Availability availability) : base(aggregateId)
    {
        BeerId = aggregateId;
        Availability = availability;
    }
}