using BrewUp.Sales.ReadModel.Services;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;

namespace BrewUp.Sales.Facade;

public sealed class SalesFacade : ISalesFacade
{
    private readonly ISalesOrderService _salesOrderService;

    public SalesFacade(ISalesOrderService salesOrderService)
    {
        _salesOrderService = salesOrderService;
    }

    public async Task<string> CreateOrderAsync(SalesOrderJson body, CancellationToken cancellationToken)
    {
        if (body.SalesOrderId.Equals(Guid.Empty))
            body = body with {SalesOrderId = Guid.NewGuid()};
        

        return body.SalesOrderId.ToString();
    }

    public async Task<PagedResult<SalesOrderJson>> GetOrdersAsync(CancellationToken cancellationToken)
    {
        return await _salesOrderService.GetSalesOrdersAsync(0, 100, cancellationToken);
    }
}