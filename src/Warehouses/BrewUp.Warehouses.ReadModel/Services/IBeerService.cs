using System.Linq.Expressions;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;
using BrewUp.Warehouses.ReadModel.Entities;

namespace BrewUp.Warehouses.ReadModel.Services;

public interface IBeerService
{
    Task<PagedResult<BeerJson>> GetBeersAsync(Expression<Func<Beer, bool>>? query, int page, int pageSize,
        CancellationToken cancellationToken);
}