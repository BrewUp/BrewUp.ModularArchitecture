using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;

namespace BrewUp.Sales.Facade;

public sealed class SalesFacade : ISalesFacade
{
    public SalesFacade()
    {
    }

    public Task<string> CreateOrderAsync(SalesOrderJson body, CancellationToken cancellationToken)
    {
        if (body.SalesOrderId.Equals(Guid.Empty))
            body = body with {SalesOrderId = Guid.NewGuid()};
        
        return Task.FromResult(body.SalesOrderId.ToString());
    }

    public Task<PagedResult<SalesOrderJson>> GetOrdersAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(new PagedResult<SalesOrderJson>(Enumerable.Empty<SalesOrderJson>(), 0, 0, 0));
    }
}