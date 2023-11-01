using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Core;

namespace BrewUp.Sales.Domain.Entities;

public class SalesOrderLine : Entity
{
    internal readonly BeerId _beerId;
    internal readonly BeerName _beerName;
    internal readonly Quantity _quantity;
    internal readonly Price _price;

    protected SalesOrderLine()
    {
    }

    internal static SalesOrderLine CreateSalesOrderLine(BeerId beerId, BeerName beerName, Quantity quantity,
        Price price) => new (beerId, beerName, quantity, price);

    private SalesOrderLine(BeerId beerId, BeerName beerName, Quantity quantity, Price price)
    {
        _beerId = beerId;
        _beerName = beerName;
        _quantity = quantity;
        _price = price;
    }
}