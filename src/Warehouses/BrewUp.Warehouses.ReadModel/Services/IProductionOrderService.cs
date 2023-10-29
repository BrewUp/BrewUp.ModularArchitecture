using BrewUp.Shared.Dtos;
using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;

namespace BrewUp.Warehouses.ReadModel.Services;

public interface IProductionOrderService
{
    Task CreateProductionOrderAsync(ProductionOrderId productionOrderId, ProductionOrderNumber productionOrderNumber,
        OrderDate orderDate, IEnumerable<ProductionOrderRow> rows, CancellationToken cancellationToken = new());
}