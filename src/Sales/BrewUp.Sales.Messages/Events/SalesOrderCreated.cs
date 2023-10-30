using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Sales.Messages.Events;

public sealed class SalesOrderCreated : DomainEvent
{
    public readonly SalesOrderId SalesOrderId;
    public readonly SalesOrderNumber SalesOrderNumber;
    public readonly PubId PubId;
    public readonly PubName PubName;
    public readonly OrderDate OrderDate;

    public readonly IEnumerable<SalesOrderRowDto> Rows;

    public SalesOrderCreated(SalesOrderId aggregateId, SalesOrderNumber salesOrderNumber, PubId pubId, PubName pubName,
        OrderDate orderDate, IEnumerable<SalesOrderRowDto> rows) : base(aggregateId)
    {
        SalesOrderId = aggregateId;
        SalesOrderNumber = salesOrderNumber;
        
        PubId = pubId;
        PubName = pubName;
        
        OrderDate = orderDate;

        Rows = rows;
    }
}