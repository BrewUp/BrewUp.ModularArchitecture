using BrewUp.Warehouses.Facade.BindingModels;

namespace BrewUp.Warehouses.Facade;

public sealed class WarehousesFacade : IWarehousesFacade
{
    public Task<string> CreateWarehouseAsync(WarehouseJson body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<WarehouseJson>> GetWarehousesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}