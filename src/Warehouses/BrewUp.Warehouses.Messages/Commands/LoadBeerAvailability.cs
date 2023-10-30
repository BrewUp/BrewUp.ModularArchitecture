using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Warehouses.Messages.Commands;

public sealed class LoadBeerAvailability : Command
{
    public readonly BeerId BeerId;
    public readonly Availability Availability;
    
    public LoadBeerAvailability(BeerId aggregateId, Availability availability) : base(aggregateId)
    {
        BeerId = aggregateId;
        Availability = availability;
    }
}