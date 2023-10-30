using BrewUp.Production.Domain.Helpers;
using BrewUp.Production.Messages.Events;
using BrewUp.Production.SharedKernel.DomainIds;
using BrewUp.Production.SharedKernel.Dtos;
using BrewUp.Shared.Dtos;
using Muflone.Core;

namespace BrewUp.Production.Domain.Entities;

public sealed class ProductionOrder : AggregateRoot
{
    private ProductionOrderNumber _productionOrderNumber;
    private OrderDate _orderDate;

    private IEnumerable<ProductionOrderRow> _rows;
    
    protected ProductionOrder()
    {}
    
    internal static ProductionOrder CreateProductionOrder(ProductionOrderId productionOrderId, ProductionOrderNumber productionOrderNumber,
        OrderDate orderDate, IEnumerable<Production.SharedKernel.Dtos.ProductionOrderRow> rows)
    {
        return new ProductionOrder(productionOrderId, productionOrderNumber, orderDate, rows);
    }
    
    private ProductionOrder(ProductionOrderId productionOrderId, ProductionOrderNumber productionOrderNumber,
        OrderDate orderDate, IEnumerable<Production.SharedKernel.Dtos.ProductionOrderRow> rows)
    {
        RaiseEvent(new ProductionOrderCreated(productionOrderId, productionOrderNumber, orderDate, rows));
    }

    private void Apply(ProductionOrderCreated @event)
    {
        Id = @event.AggregateId;
        
        _productionOrderNumber = @event.ProductionOrderNumber;
        _orderDate = @event.OrderDate;
        
        _rows = @event.Rows.ToDomainEntities();
    }
}