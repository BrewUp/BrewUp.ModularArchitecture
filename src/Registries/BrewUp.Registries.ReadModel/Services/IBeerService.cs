using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.Registries.ReadModel.Services;

public interface IBeerService
{
    Task CreateBeerAsync(BeerId beerId, BeerName beerName, BeerType beerType, CancellationToken cancellationToken);
    Task<PagedResult<BeerJson>> GetBeersAsync(object o, int i, int i1, CancellationToken cancellationToken);
}