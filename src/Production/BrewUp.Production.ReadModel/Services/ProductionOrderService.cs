using BrewUp.Production.ReadModel.Entities;
using BrewUp.Production.SharedKernel.DomainIds;
using BrewUp.Production.SharedKernel.Dtos;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;

namespace BrewUp.Production.ReadModel.Services;

public sealed class ProductionOrderService : ServiceBase, IProductionOrderService
{
    private readonly IQueries<ProductionOrder> _queries;
    
    public ProductionOrderService(ILoggerFactory loggerFactory,
        IPersister persister,
        IQueries<ProductionOrder> queries) : base(loggerFactory, persister)
    {
        _queries = queries;
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

    public async Task CompleteProductionOrderAsync(ProductionOrderId productionOrderId,
        CancellationToken cancellationToken = new ())
    {
        var productionOrder = await _queries.GetByIdAsync(productionOrderId.Value.ToString(), cancellationToken);
        productionOrder.Complete();
        await Persister.UpdateAsync(productionOrder, cancellationToken);
    }

    public async Task<PagedResult<ProductionOrderJson>> GetProductionOrdersAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            var ordersResult = await _queries.GetByFilterAsync(null, 0, 100, cancellationToken);
            
            return ordersResult.TotalRecords > 0
                ? new PagedResult<ProductionOrderJson>(ordersResult.Results.Select(r => r.ToJson()), ordersResult.Page, ordersResult.PageSize, ordersResult.TotalRecords)
                : new PagedResult<ProductionOrderJson>(Enumerable.Empty<ProductionOrderJson>(), 0, 0, 0);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error reading ProductionOrders");
            throw;
        }
    }
}