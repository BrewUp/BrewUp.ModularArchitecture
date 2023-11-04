using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;

namespace BrewUp.Production.Facade;

public interface IProductionFacade
{
    Task<PagedResult<ProductionOrderJson>> GetProductionOrdersAsync(CancellationToken cancellationToken);
}