using BrewUp.Production.Messages.Commands;
using BrewUp.Production.ReadModel.Services;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
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

    public async Task CompleteProductionOrderAsync(Guid productionOrderId, CancellationToken cancellationToken)
    {
        // Check Order exists
        CompleteProductionOrder completeProductionOrder = new(new ProductionOrderId(productionOrderId), Guid.NewGuid());
        await _serviceBus.SendAsync(completeProductionOrder, cancellationToken);
    }
}