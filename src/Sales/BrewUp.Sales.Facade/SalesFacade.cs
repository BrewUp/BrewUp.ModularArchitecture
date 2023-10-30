using BrewUp.Sales.Messages.Commands;
using BrewUp.Sales.ReadModel.Services;
using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;
using Muflone.Persistence;

namespace BrewUp.Sales.Facade;

public sealed class SalesFacade : ISalesFacade
{
    private readonly IServiceBus _serviceBus;
    private readonly ISalesOrderService _salesOrderService;

    public SalesFacade(IServiceBus serviceBus, ISalesOrderService salesOrderService)
    {
        _serviceBus = serviceBus;
        _salesOrderService = salesOrderService;
    }

    public async Task<string> CreateOrderAsync(SalesOrderJson body, CancellationToken cancellationToken)
    {
        if (body.SalesOrderId.Equals(Guid.Empty))
            body = body with {SalesOrderId = Guid.NewGuid()};
        
        CreateSalesOrder createSalesOrder = new(new SalesOrderId(body.SalesOrderId),
            new SalesOrderNumber(body.SalesOrderNumber),
            new PubId(body.PubId), new PubName(body.PubName), new OrderDate(body.OrderDate), 
            body.Rows.Select(x => new SalesOrderRowDto(
                new BeerId(x.BeerId), new BeerName(x.BeerName), x.Quantity, x.Price)));

        await _serviceBus.SendAsync(createSalesOrder, cancellationToken);

        return body.SalesOrderId.ToString();
    }

    public async Task<PagedResult<SalesOrderJson>> GetOrdersAsync(CancellationToken cancellationToken)
    {
        return await _salesOrderService.GetSalesOrdersAsync(0, 100, cancellationToken);
    }
}