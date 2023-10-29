using BrewUp.Shared.Dtos;
using BrewUp.Shared.ReadModel;
using BrewUp.Warehouses.ReadModel.Entities;
using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;
using Microsoft.Extensions.Logging;

namespace BrewUp.Warehouses.ReadModel.Services;

public sealed class ProductionOrderService : ServiceBase, IProductionOrderService
{
    public ProductionOrderService(ILoggerFactory loggerFactory, IPersister persister) : base(loggerFactory, persister)
    {
    }

    public async Task CreateProductionOrderAsync(ProductionOrderId productionOrderId, ProductionOrderNumber productionOrderNumber,
        OrderDate orderDate, IEnumerable<ProductionOrderRow> rows, CancellationToken cancellationToken = new ())
    {
        try
        {
            var productionOrder = ProductionOrder.CreateProductionOrder(productionOrderId, productionOrderNumber, orderDate, rows);
            await Persister.InsertAsync(productionOrder, cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error creating production order");
            throw;
        }
    }
}