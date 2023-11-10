
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

    private Status _status;

    protected SalesOrder()
    {
    }

    #region Create
    internal static SalesOrder CreateSalesOrder(SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber,
        PubId pubId, PubName pubName, OrderDate orderDate, IEnumerable<SalesOrderRowDto> lines) =>
        new(salesOrderId, salesOrderNumber, pubId, pubName, orderDate, lines);

    private SalesOrder(SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber, PubId pubId, PubName pubName,
        OrderDate orderDate, IEnumerable<SalesOrderRowDto> lines)
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
        
        _status = Status.Created;
    }
    #endregion
    
    #region Complete

    internal void Complete(SalesOrderId salesOrderId, IEnumerable<BrewedRow> rows)
    {
        if (_status.Id != Status.Created.Id)
        {
            RaiseEvent(new SalesOrderAlreadyCompleted(Id));
            return;
        }
        
        RaiseEvent(new SalesOrderCompleted(salesOrderId, _lines.ToDtos()));
    }
    
    private void Apply(SalesOrderAlreadyCompleted @event)
    {
    }

    private void Apply(SalesOrderCompleted @event)
    {
        _status = Status.Completed;
    }
    #endregion
}