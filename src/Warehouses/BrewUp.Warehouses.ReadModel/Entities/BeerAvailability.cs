using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.Warehouses.ReadModel.Entities;

public class BeerAvailability : EntityBase
{
    public string Name { get; private set; } = string.Empty;
    
    public Availability Availability { get; private set; } = new(0, string.Empty);
    
    protected BeerAvailability()
    {}

    public static BeerAvailability CreateBeerAvailability(BeerId beerId, BeerName beerName) => new(beerId.ToString(), beerName.Value);
    
    private BeerAvailability(string beerId, string beerName)
    {
        Id = beerId;
        Name = beerName;
    }
    
    public BeerAvailabilityJson ToJson() => new()
    {
        BeerId = Id,
        BeerName = Name,
        Availability = Availability
    };
}