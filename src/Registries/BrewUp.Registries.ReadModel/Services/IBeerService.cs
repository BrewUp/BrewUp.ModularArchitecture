using System.Linq.Expressions;
using BrewUp.Registries.ReadModel.Entities;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.Registries.ReadModel.Services;

public interface IBeerService
{
    Task<string> CreateBeerAsync(BeerId beerId, BeerName beerName, BeerType beerType, HomeBrewed homeBrewed,
        CancellationToken cancellationToken);
    
    Task<PagedResult<BeerJson>> GetBeersAsync(Expression<Func<Beer, bool>>? query, int page, int pageSize,
        CancellationToken cancellationToken);
}