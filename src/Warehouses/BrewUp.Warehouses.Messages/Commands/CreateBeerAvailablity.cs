using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Warehouses.Messages.Commands;

public sealed class CreateBeerAvailablity : Command
{
    public readonly BeerId BeerId;
    public readonly BeerName BeerName;
    
    public CreateBeerAvailablity(BeerId aggregateId, BeerName beerName) : base(aggregateId)
    {
        BeerId = aggregateId;
        BeerName = beerName;
    }
}