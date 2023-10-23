using BrewUp.Sales.Facade.BindingModels;

namespace BrewUp.Sales.Facade;

public sealed class SalesFacade : ISalesFacade
{
    public Task<string> CreateOrderAsync(SalesOrderJson body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SalesOrderJson>> GetOrdersAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}