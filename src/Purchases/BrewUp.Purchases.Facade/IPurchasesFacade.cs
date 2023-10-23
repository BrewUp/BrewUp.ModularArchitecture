using BrewUp.Purchases.Facade.BindingModels;

namespace BrewUp.Purchases.Facade;

public interface IPurchasesFacade
{
    Task<string> CreateOrderAsync(PurchasesOrderJson body, CancellationToken cancellationToken);
    Task<IEnumerable<PurchasesOrderJson>> GetOrdersAsync(CancellationToken cancellationToken);
}