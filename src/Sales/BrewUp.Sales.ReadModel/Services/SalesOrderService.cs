using BrewUp.Sales.ReadModel.Entities;
using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;

namespace BrewUp.Sales.ReadModel.Services;

public sealed class SalesOrderService : ServiceBase, ISalesOrderService
{
    private readonly IQueries<SalesOrder> _queries;
    public SalesOrderService(ILoggerFactory loggerFactory, IPersister persister, IQueries<SalesOrder> queries) : base(loggerFactory, persister)
    {
        _queries = queries;
    }

    public async Task CreateSalesOrderAsync(SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber, PubId pubId,
        PubName pubName, OrderDate orderDate, IEnumerable<SalesOrderLineDto> rows, CancellationToken cancellationToken)
    {
        try
        {
            var salesOrder = SalesOrder.CreateSalesOrder(salesOrderId, salesOrderNumber, pubId, pubName, orderDate, rows);
            await Persister.InsertAsync(salesOrder, cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error creating sales order");
            throw;
        }
    }

    public async Task<PagedResult<SalesOrderJson>> GetSalesOrdersAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        try
        {
            var beersResult = await _queries.GetByFilterAsync(null, page, pageSize, cancellationToken);
            
            return beersResult.TotalRecords > 0
                ? new PagedResult<SalesOrderJson>(beersResult.Results.Select(r => r.ToJson()), beersResult.Page, beersResult.PageSize, beersResult.TotalRecords)
                : new PagedResult<SalesOrderJson>(Enumerable.Empty<SalesOrderJson>(), 0, 0, 0);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error reading SalesOrders");
            throw;
        }
    }
}