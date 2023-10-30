using BrewUp.Production.ReadModel.Services;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;

namespace BrewUp.Production.Facade;

public sealed class ProductionFacade : IProductionFacade
{
    private readonly IProductionOrderService _productionOrderService;

    public ProductionFacade(IProductionOrderService productionOrderService)
    {
        _productionOrderService = productionOrderService;
    }

    public async Task<PagedResult<ProductionOrderJson>> GetProductionOrdersAsync(CancellationToken cancellationToken)
    {
        return await _productionOrderService.GetProductionOrdersAsync(cancellationToken);
    }
}