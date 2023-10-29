using BrewUp.Shared.Dtos;
using BrewUp.Warehouses.Domain.Helpers;
using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;
using Muflone.Core;

namespace BrewUp.Warehouses.Domain.Entities;

public sealed class ProductionOrder : AggregateRoot
{
    private ProductionOrderNumber _productionOrderNumber;
    private OrderDate _orderDate;

    private IEnumerable<ProductionOrderRow> _rows;
    
    protected ProductionOrder()
    {}
    
    internal static ProductionOrder CreateProductionOrder(ProductionOrderId productionOrderId, ProductionOrderNumber productionOrderNumber,
        OrderDate orderDate, IEnumerable<Warehouses.SharedKernel.Dtos.ProductionOrderRow> rows)
    {
        return new ProductionOrder(productionOrderId, productionOrderNumber, orderDate, rows);
    }
    
    private ProductionOrder(ProductionOrderId productionOrderId, ProductionOrderNumber productionOrderNumber,
        OrderDate orderDate, IEnumerable<Warehouses.SharedKernel.Dtos.ProductionOrderRow> rows)
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