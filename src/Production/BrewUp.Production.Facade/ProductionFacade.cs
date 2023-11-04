using BrewUp.Production.ReadModel.Services;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;
using Muflone.Persistence;

namespace BrewUp.Production.Facade;

public sealed class ProductionFacade : IProductionFacade
{
    private readonly IServiceBus _serviceBus;
    private readonly IProductionOrderService _productionOrderService;

    public ProductionFacade(IServiceBus serviceBus,
        IProductionOrderService productionOrderService)
    {
        _serviceBus = serviceBus;
        _productionOrderService = productionOrderService;
    }

    public async Task<PagedResult<ProductionOrderJson>> GetProductionOrdersAsync(CancellationToken cancellationToken)
    {
        return await _productionOrderService.GetProductionOrdersAsync(cancellationToken);
    }
}