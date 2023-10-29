using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Warehouses.Domain.CommandHandlers;
using BrewUp.Warehouses.Messages.Commands;
using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace BrewUp.Warehouses.Domain.Tests.Entities;

public sealed class CreateProductionOrderSuccessfully : CommandSpecification<CreateProductionOrder>
{
    private readonly ProductionOrderId _productionOrderId = new(Guid.NewGuid());
    private readonly ProductionOrderNumber _productionOrderNumber = new("20231108-01");
    private readonly OrderDate _orderDate = new(DateTime.UtcNow);

    private readonly IEnumerable<ProductionOrderRow> _rows = Enumerable.Empty<ProductionOrderRow>();

    public CreateProductionOrderSuccessfully()
    {
        _rows = _rows.Concat(new List<ProductionOrderRow>
        {
            new(new BeerId(Guid.NewGuid()), new BeerName("Beer 1"), new Quantity(10, "NR"))
        });
    }
    
    protected override IEnumerable<DomainEvent> Given()
    {
        yield break;
    }

    protected override CreateProductionOrder When()
    {
        return new CreateProductionOrder(_productionOrderId, _productionOrderNumber, _orderDate, _rows);
    }

    protected override ICommandHandlerAsync<CreateProductionOrder> OnHandler()
    {
        return new CreateProductionOrderCommandHandler(Repository, new NullLoggerFactory());
    }

    protected override IEnumerable<DomainEvent> Expect()
    {
        yield return new ProductionOrderCreated(_productionOrderId, _productionOrderNumber, _orderDate, _rows);
    }
}