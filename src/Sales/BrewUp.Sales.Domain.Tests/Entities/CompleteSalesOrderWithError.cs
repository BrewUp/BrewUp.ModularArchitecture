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

public sealed class CompleteSalesOrderWithError : CommandSpecification<CompleteSalesOrder>
{
    private readonly SalesOrderId _salesOrderId = new(Guid.NewGuid());
    private readonly SalesOrderNumber _salesOrderNumber = new("2023-11-09");
    
    private readonly PubId _pubId = new(Guid.NewGuid());
    private readonly PubName _pubName = new("Pub Name");
    
    private readonly OrderDate _orderDate = new (DateTime.Today);

    private readonly IEnumerable<SalesOrderRowDto> _lines = Enumerable.Empty<SalesOrderRowDto>();
    private readonly IEnumerable<BrewedRow> _brewedBeers = Enumerable.Empty<BrewedRow>();
    
    public CompleteSalesOrderWithError()
    {
        var beerId = new BeerId(Guid.NewGuid());
        var beerName = new BeerName("Muflone IPA");
        
        _lines = _lines.Concat(new List<SalesOrderRowDto>
        {
            new(beerId, beerName, new Quantity(20, "lt"), new Price(2.5m, "€"))
        });

        _brewedBeers = _brewedBeers.Concat(new List<BrewedRow>
        {
            new BrewedRow(beerId, beerName, new Quantity(20, "lt"))
        });
    }
    
    protected override IEnumerable<DomainEvent> Given()
    {
        yield return new SalesOrderCreated(_salesOrderId, _salesOrderNumber, _pubId, _pubName, _orderDate, _lines);
        yield return new SalesOrderCompleted(_salesOrderId, _lines);
    }

    protected override CompleteSalesOrder When()
    {
        return new CompleteSalesOrder(_salesOrderId, _brewedBeers);
    }

    protected override ICommandHandlerAsync<CompleteSalesOrder> OnHandler()
    {
        return new CompleteSalesOrderCommandHandler(Repository, new NullLoggerFactory());
    }

    protected override IEnumerable<DomainEvent> Expect()
    {
        yield return new SalesOrderAlreadyCompleted(_salesOrderId);
    }
}