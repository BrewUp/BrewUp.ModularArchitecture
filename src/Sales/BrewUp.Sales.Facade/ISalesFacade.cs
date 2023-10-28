using BrewUp.Sales.Facade.BindingModels;
using BrewUp.Shared.BindingModels;

namespace BrewUp.Sales.Facade;

public interface ISalesFacade
{
    Task<string> CreateOrderAsync(SalesOrderModel body, CancellationToken cancellationToken);
    Task<IEnumerable<SalerOrderJson>> GetOrdersAsync(CancellationToken cancellationToken);
}