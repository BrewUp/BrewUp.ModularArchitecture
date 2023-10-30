using BrewUp.Production.ReadModel.Entities;
using BrewUp.Production.SharedKernel.DomainIds;
using BrewUp.Production.SharedKernel.Dtos;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;

namespace BrewUp.Production.ReadModel.Services;

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