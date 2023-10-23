using BrewUp.Purchases.Facade.BindingModels;

namespace BrewUp.Purchases.Facade;

public sealed class PurchasesFacade : IPurchasesFacade
{
    public Task<string> CreateOrderAsync(PurchasesOrderJson body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PurchasesOrderJson>> GetOrdersAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}