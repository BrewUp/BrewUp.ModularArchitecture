using BrewUp.Sales.ReadModel.Entities;
using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;

namespace BrewUp.Sales.ReadModel.Services;

public sealed class SalesOrderService : ServiceBase, ISalesOrderService
{
    public SalesOrderService(ILoggerFactory loggerFactory, IPersister persister) : base(loggerFactory, persister)
    {
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
}