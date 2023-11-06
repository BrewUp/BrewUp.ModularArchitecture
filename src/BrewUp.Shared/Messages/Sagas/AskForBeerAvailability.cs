using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class AskForBeerAvailability : Command
{
    public readonly BeerId BeerId;
    public readonly BeerName BeerName;
    
    public AskForBeerAvailability(BeerId aggregateId, Guid commitId, BeerName beerName) : base(aggregateId, commitId)
    {
        BeerId = aggregateId;
        BeerName = beerName;
    }
}