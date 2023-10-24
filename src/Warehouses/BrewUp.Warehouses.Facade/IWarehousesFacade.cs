using BrewUp.Shared.BindingModels;
using BrewUp.Shared.Entities;
using BrewUp.Warehouses.Facade.BindingModels;

namespace BrewUp.Warehouses.Facade;

public interface IWarehousesFacade
{
    Task<string> CreateWarehouseAsync(WarehouseJson body, CancellationToken cancellationToken);
    
    Task<PagedResult<WarehouseJson>> GetWarehousesAsync(CancellationToken cancellationToken);
    Task<PagedResult<BeerJson>> GetBeersAsync(CancellationToken cancellationToken);
}