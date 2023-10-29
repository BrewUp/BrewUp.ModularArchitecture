using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;

namespace BrewUp.Warehouses.Facade;

public interface IWarehousesFacade
{
    Task<string> CreateWarehouseAsync(WarehouseJson body, CancellationToken cancellationToken);
    
    Task<PagedResult<WarehouseJson>> GetWarehousesAsync(CancellationToken cancellationToken);
}