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
    private CustomerId _customerId;
    private OrderDate _orderDate;

    private IEnumerable<SalesOrderLine> _lines;

    protected SalesOrder()
    {
    }

    internal static SalesOrder CreateSalesOrder(SalesOrderId salesOrderId, CustomerId customerId, OrderDate orderDate, IEnumerable<SalesOrderLineDto> lines) 
        => new(salesOrderId, customerId, orderDate, lines);
    
    private SalesOrder(SalesOrderId salesOrderId, CustomerId customerId, OrderDate orderDate, IEnumerable<SalesOrderLineDto> lines)
    {
        RaiseEvent(new SalesOrderCreated(salesOrderId, customerId, orderDate, lines ));
    }

    private void Apply(SalesOrderCreated @event)
    {
        Id = @event.SalesOrderId;
        
        _customerId = @event.CustomerId;
        _orderDate = @event.OrderDate;
        
        _lines = @event.Lines.ToDomainEntities();
    }
}