using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;
using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;

namespace BrewUp.Warehouses.ReadModel.Entities;

public class ProductionOrder : EntityBase
{
    public string ProductionOrderNumber { get; private set; } = string.Empty;
    
    public DateTime OrderDate { get; private set; } = DateTime.MinValue;
    
    public IEnumerable<ProductionOrderRow> Rows { get; private set; } = Enumerable.Empty<ProductionOrderRow>();
    
    protected ProductionOrder()
    {}
    
    internal static ProductionOrder CreateProductionOrder(ProductionOrderId productionOrderId, ProductionOrderNumber productionOrderNumber,
        OrderDate orderDate, IEnumerable<ProductionOrderRow> rows) => new(productionOrderId.Value, productionOrderNumber.Value, orderDate.Value, rows);

    private ProductionOrder(Guid productionOrderId, string productionOrderNumber, DateTime orderData,
        IEnumerable<ProductionOrderRow> rows)
    {
        Id = productionOrderId.ToString();
        ProductionOrderNumber = productionOrderNumber;
        OrderDate = orderData;
        Rows = rows;
    }
}