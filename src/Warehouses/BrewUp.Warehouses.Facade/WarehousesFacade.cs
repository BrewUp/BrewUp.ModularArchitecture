using BrewUp.Shared.BindingModels;
using BrewUp.Shared.Entities;
using BrewUp.Warehouses.Facade.BindingModels;
using BrewUp.Warehouses.ReadModel.Services;

namespace BrewUp.Warehouses.Facade;

public sealed class WarehousesFacade : IWarehousesFacade
{
    private readonly IBeerService _beerService;

    public WarehousesFacade(IBeerService beerService)
    {
        _beerService = beerService;
    }

    public Task<string> CreateWarehouseAsync(WarehouseJson body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<WarehouseJson>> GetWarehousesAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public Task<PagedResult<BeerJson>> GetBeersAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}