using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Core;

namespace BrewUp.Sales.Domain.Entities;

public class SalesOrderLine : Entity
{
    private readonly ProductId _productId;
    private readonly ProductName _productName;
    private readonly Quantity _quantity;
    private readonly Price _price;

    protected SalesOrderLine()
    {
    }

    internal static SalesOrderLine CreateSalesOrderLine(ProductId productId, ProductName productName, Quantity quantity,
        Price price) => new (productId, productName, quantity, price);

    private SalesOrderLine(ProductId productId, ProductName productName, Quantity quantity, Price price)
    {
        _productId = productId;
        _productName = productName;
        _quantity = quantity;
        _price = price;
    }
}