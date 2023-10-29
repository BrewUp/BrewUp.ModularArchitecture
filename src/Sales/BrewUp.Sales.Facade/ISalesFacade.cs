using BrewUp.Shared.Contracts;

namespace BrewUp.Sales.Facade;

public interface ISalesFacade
{
    Task<string> CreateOrderAsync(SalerOrderJson body, CancellationToken cancellationToken);
    Task<IEnumerable<SalerOrderJson>> GetOrdersAsync(CancellationToken cancellationToken);
}