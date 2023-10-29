using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.Warehouses.ReadModel.Entities;

public class Beer : EntityBase
{
    public string Name { get; private set; } = string.Empty;
    
    protected Beer()
    {}

    public static Beer CreateBeer(BeerId beerId, BeerName beerName) => new(beerId.ToString(), beerName.Value);
    
    private Beer(string beerId, string beerName)
    {
        Id = beerId;
        Name = beerName;
    }
    
    public BeerJson ToJson() => new()
    {
        BeerId = Id,
        BeerName = Name
    };
}