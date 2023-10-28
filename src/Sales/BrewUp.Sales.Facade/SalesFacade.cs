using BrewUp.Sales.Facade.BindingModels;
using BrewUp.Sales.Messages.Commands;
using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.BindingModels;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Persistence;

namespace BrewUp.Sales.Facade;

public sealed class SalesFacade : ISalesFacade
{
    private readonly IServiceBus _serviceBus;

    public SalesFacade(IServiceBus serviceBus)
    {
        _serviceBus = serviceBus;
    }

    public async Task<string> CreateOrderAsync(SalesOrderModel body, CancellationToken cancellationToken)
    {
        if (body.SalesOrderId.Equals(Guid.Empty))
            body = body with {SalesOrderId = Guid.NewGuid()};
        
        CreateSalesOrder createSalesOrder = new(new SalesOrderId(body.SalesOrderId),
            new PubId(body.PubId), new PubName(body.PubName), new OrderDate(body.OrderDate), 
            body.Rows.Select(x => new SalesOrderLineDto(
                new BeerId(x.BeerId), new BeerName(x.BeerName), x.Quantity, x.Price)));

        await _serviceBus.SendAsync(createSalesOrder, cancellationToken);

        return body.SalesOrderId.ToString();
    }

    public Task<IEnumerable<SalerOrderJson>> GetOrdersAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}