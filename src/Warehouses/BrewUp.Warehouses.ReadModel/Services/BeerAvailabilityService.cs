using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;
using BrewUp.Shared.ReadModel;
using BrewUp.Warehouses.ReadModel.Entities;
using Microsoft.Extensions.Logging;

namespace BrewUp.Warehouses.ReadModel.Services;

public sealed class BeerAvailabilityService : ServiceBase, IBeerAvailabilityService
{
    private readonly IQueries<BeerAvailability> _queries;
    
    public BeerAvailabilityService(ILoggerFactory loggerFactory, IPersister persister, IQueries<BeerAvailability> queries) : base(loggerFactory, persister)
    {
        _queries = queries;
    }

    public async Task<PagedResult<BeerAvailabilityJson>> GetBeerAvailabilitiesAsync(Guid beerId, int page, int pageSize,
        CancellationToken cancellationToken = default)
    {
        var beerAvailability =
            await _queries.GetByFilterAsync(b => b.Id.Equals(beerId.ToString()), 0, 100, cancellationToken);
        
        return beerAvailability.TotalRecords > 0
            ? new PagedResult<BeerAvailabilityJson>(beerAvailability.Results.Select(r => r.ToJson()), beerAvailability.Page, beerAvailability.PageSize, beerAvailability.TotalRecords)
            : new PagedResult<BeerAvailabilityJson>(Enumerable.Empty<BeerAvailabilityJson>(), 0, 0, 0);
    }
}