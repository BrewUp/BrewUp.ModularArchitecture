using BrewUp.Sales.Domain.Helpers;
using BrewUp.Sales.Messages.Events;
using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Core;

namespace BrewUp.Sales.Domain.Entities;

public sealed class SalesOrder : AggregateRoot
{
    private SalesOrderNumber _salesOrderNumber;
    
    private PubId _pubId;
    private PubName _pubName;
    
    private OrderDate _orderDate;

    private IEnumerable<SalesOrderLine> _lines;

    protected SalesOrder()
    {
    }

    internal static SalesOrder CreateSalesOrder(SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber,
        PubId pubId, PubName pubName, OrderDate orderDate, IEnumerable<SalesOrderLineDto> lines) =>
        new(salesOrderId, salesOrderNumber, pubId, pubName, orderDate, lines);

    private SalesOrder(SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber, PubId pubId, PubName pubName,
        OrderDate orderDate, IEnumerable<SalesOrderLineDto> lines)
    {
        RaiseEvent(new SalesOrderCreated(salesOrderId, salesOrderNumber, pubId, pubName, orderDate, lines ));
    }

    private void Apply(SalesOrderCreated @event)
    {
        Id = @event.SalesOrderId;
        _salesOrderNumber = @event.SalesOrderNumber;
        
        _pubId = @event.PubId;
        _pubName = @event.PubName;
        
        _orderDate = @event.OrderDate;
        
        _lines = @event.Rows.ToDomainEntities();
    }
}