using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Core;

namespace BrewUp.Sales.Domain.Entities;

public class SalesOrderLine : Entity
{
    private readonly BeerId _beerId;
    private readonly BeerName _beerName;
    private readonly Quantity _quantity;
    private readonly Price _price;

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