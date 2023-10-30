using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;

namespace BrewUp.Production.Facade;

public sealed class ProductionFacade : IProductionFacade
{
    public Task<PagedResult<ProductionOrderJson>> GetProductionOrdersAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}