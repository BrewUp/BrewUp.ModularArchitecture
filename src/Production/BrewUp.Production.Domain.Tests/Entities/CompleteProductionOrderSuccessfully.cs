using BrewUp.Production.Domain.CommandHandlers;
using BrewUp.Production.Messages.Commands;
using BrewUp.Production.Messages.Events;
using BrewUp.Production.SharedKernel.DomainIds;
using BrewUp.Production.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace BrewUp.Production.Domain.Tests.Entities;

public sealed class CompleteProductionOrderSuccessfully : CommandSpecification<CompleteProductionOrder>
{
    private readonly ProductionOrderId _productionOrderId = new(Guid.NewGuid());
    private readonly ProductionOrderNumber _productionOrderNumber = new("20231108-01");
    private readonly OrderDate _orderDate = new(DateTime.UtcNow);

    private readonly IEnumerable<ProductionOrderRow> _rows = Enumerable.Empty<ProductionOrderRow>();

    public CompleteProductionOrderSuccessfully()
    {
        _rows = _rows.Concat(new List<ProductionOrderRow>
        {
            new(new BeerId(Guid.NewGuid()), new BeerName("Beer 1"), new Quantity(10, "NR"))
        });
    }
    
    protected override IEnumerable<DomainEvent> Given()
    {
        yield return new ProductionOrderCreated(_productionOrderId, _productionOrderNumber, _orderDate, _rows);
    }

    protected override CompleteProductionOrder When()
    {
        return new CompleteProductionOrder(_productionOrderId);
    }

    protected override ICommandHandlerAsync<CompleteProductionOrder> OnHandler()
    {
        return new CompleteProductionOrderCommandHandler(Repository, new NullLoggerFactory());
    }

    protected override IEnumerable<DomainEvent> Expect()
    {
        yield return new ProductionOrderCompleted(_productionOrderId, _rows);
    }
}