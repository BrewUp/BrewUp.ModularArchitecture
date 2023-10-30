using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.Sales.ReadModel.Services;

public interface ISalesOrderService
{
    Task CreateSalesOrderAsync(SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber, PubId pubId,
        PubName pubName, OrderDate orderDate, IEnumerable<SalesOrderLineDto> rows, CancellationToken cancellationToken);
    
    Task<PagedResult<SalesOrderJson>> GetSalesOrdersAsync(int page, int pageSize, CancellationToken cancellationToken);
}