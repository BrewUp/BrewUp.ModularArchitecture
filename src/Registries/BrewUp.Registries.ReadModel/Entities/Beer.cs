using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.Registries.ReadModel.Entities;

public class Beer : EntityBase
{
    public string BeerName { get; set; } = string.Empty;
    public string BeerType { get; set; } = string.Empty;

    protected Beer()
    {
    }

    public static Beer CreateBeer(BeerId beerId, BeerName beerName, BeerType beerType) =>
        new (beerId.Value.ToString(), beerName.Value, beerType.Value);
    
    private Beer(string beerId, string beerName, string beerType)
    {
        Id = beerId;
        BeerName = beerName;
        BeerType = beerType;
    }
    
    public BeerJson ToJson() => new()
    {
        BeerId = Id,
        BeerName = BeerName,
        BeerType = BeerType
    };

}