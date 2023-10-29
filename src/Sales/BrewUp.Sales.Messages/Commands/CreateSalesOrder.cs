using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Sales.Messages.Commands;

public sealed class CreateSalesOrder : Command
{
    public readonly SalesOrderId SalesOrderId;
    public readonly SalesOrderNumber SalesOrderNumber;
    
    public readonly PubId PubId;
    public readonly PubName PubName;
    
    public readonly OrderDate OrderDate;

    public readonly IEnumerable<SalesOrderLineDto> Lines;

    public CreateSalesOrder(SalesOrderId aggregateId, SalesOrderNumber salesOrderNumber, PubId pubId, PubName pubName,
        OrderDate orderDate, IEnumerable<SalesOrderLineDto> lines) : base(aggregateId)
    {
        SalesOrderId = aggregateId;
        SalesOrderNumber = salesOrderNumber;
        
        PubId = pubId;
        PubName = pubName;
        
        OrderDate = orderDate;

        Lines = lines;
    }
}