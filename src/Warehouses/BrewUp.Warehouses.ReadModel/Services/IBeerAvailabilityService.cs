using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;

namespace BrewUp.Warehouses.ReadModel.Services;

public interface IBeerAvailabilityService
{
    Task<PagedResult<BeerAvailabilityJson>> GetBeerAvailabilitiesAsync(Guid beerId, int page, int pageSize,
        CancellationToken cancellationToken = default);
}