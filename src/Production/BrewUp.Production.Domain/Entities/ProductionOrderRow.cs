using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Core;

namespace BrewUp.Production.Domain.Entities;

public sealed class ProductionOrderRow : Entity
{
    internal readonly BeerId _beerId;
    internal readonly BeerName _beerName;
    internal readonly Quantity _quantity;
    
    protected ProductionOrderRow()
    {}
    
    public static ProductionOrderRow Create(BeerId beerId, BeerName beerName, Quantity quantity)
    {
        return new ProductionOrderRow(beerId, beerName, quantity);
    }
    
    private ProductionOrderRow(BeerId beerId, BeerName beerName, Quantity quantity)
    {
        _beerId = beerId;
        _beerName = beerName;
        _quantity = quantity;
    }
}