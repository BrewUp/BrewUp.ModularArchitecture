using BrewUp.Warehouses.Facade.BindingModels;

namespace BrewUp.Warehouses.Facade;

public interface IWarehousesFacade
{
    Task<string> CreateWarehouseAsync(WarehouseJson body, CancellationToken cancellationToken);
    Task<IEnumerable<WarehouseJson>> GetWarehousesAsync(CancellationToken cancellationToken);
}