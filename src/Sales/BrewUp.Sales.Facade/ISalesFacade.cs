using BrewUp.Sales.Facade.BindingModels;

namespace BrewUp.Sales.Facade;

public interface ISalesFacade
{
    Task<string> CreateOrderAsync(SalesOrderJson body, CancellationToken cancellationToken);
    Task<IEnumerable<SalesOrderJson>> GetOrdersAsync(CancellationToken cancellationToken);
}