using BrewUp.Sales.Domain.CommandHandlers;
using BrewUp.Sales.Messages.Commands;
using BrewUp.Sales.Messages.Events;
using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace BrewUp.Sales.Domain.Tests.Entities;

public sealed class CreateSalesOrderSuccesfully : CommandSpecification<CreateSalesOrder>
{
    private readonly SalesOrderId _salesOrderId = new(Guid.NewGuid());
    private readonly CustomerId _customerId = new(Guid.NewGuid());
    private readonly OrderDate _orderDate = new OrderDate(DateTime.Today);

    private readonly IEnumerable<SalesOrderLineDto> _lines;

    public CreateSalesOrderSuccesfully()
    {
        _lines = _lines.Concat(new List<SalesOrderLineDto>
        {
            new(new ProductId(Guid.NewGuid()), new ProductName("Muflone IPA"), new Quantity(20, "lt"), new Price(2.5m, "€"))
        });
    }

    protected override IEnumerable<DomainEvent> Given()
    {
        yield break;
    }

    protected override CreateSalesOrder When()
    {
        return new CreateSalesOrder(_salesOrderId, _customerId, _orderDate, _lines);
    }

    protected override ICommandHandlerAsync<CreateSalesOrder> OnHandler()
    {
        return new CreateSalesOrderCommandHandlerAsync(Repository, new NullLoggerFactory());
    }

    protected override IEnumerable<DomainEvent> Expect()
    {
        yield return new SalesOrderCreated(_salesOrderId, _customerId, _orderDate, _lines);
    }
}