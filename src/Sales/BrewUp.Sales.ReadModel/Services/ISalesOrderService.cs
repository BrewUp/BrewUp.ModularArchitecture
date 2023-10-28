using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Sales.ReadModel.Services;

public interface ISalesOrderService
{
    Task CreateSalesOrderAsync(SalesOrderId salesOrderId, PubId pubId, PubName pubName,
        OrderDate orderDate, IEnumerable<SalesOrderLineDto> rows, CancellationToken cancellationToken);
}