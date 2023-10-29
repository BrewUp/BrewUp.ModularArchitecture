using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;

namespace BrewUp.Warehouses.Facade;

public sealed class WarehousesFacade : IWarehousesFacade
{
    private readonly IBeerService _beerService;
    private readonly ILogger _logger;

    public WarehousesFacade(IBeerService beerService, ILoggerFactory loggerFactory)
    {
        _beerService = beerService ?? throw new ArgumentNullException(nameof(beerService));
        _logger = loggerFactory.CreateLogger<WarehousesFacade>() ?? throw new ArgumentNullException(nameof(loggerFactory));
    }

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

    public async Task<PagedResult<BeerJson>> GetBeersAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await _beerService.GetBeersAsync(null, 0, 100, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting beers");
            throw;
        }
    }
}