using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;
using Microsoft.Extensions.Logging;

namespace BrewUp.Warehouses.Facade;

public sealed class WarehousesFacade : IWarehousesFacade
{
    private readonly ILogger _logger;

    public Task<string> CreateWarehouseAsync(WarehouseJson body, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResult<WarehouseJson>> GetWarehousesAsync(CancellationToken cancellationToken)
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
}