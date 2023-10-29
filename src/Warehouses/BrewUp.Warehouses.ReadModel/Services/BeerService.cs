using System.Linq.Expressions;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;
using BrewUp.Shared.ReadModel;
using BrewUp.Warehouses.ReadModel.Entities;
using Microsoft.Extensions.Logging;

namespace BrewUp.Warehouses.ReadModel.Services;

public sealed class BeerService : ServiceBase, IBeerService
{
    private readonly IQueries<Beer> _queries;

    public BeerService(ILoggerFactory loggerFactory, IPersister persister, IQueries<Beer> queries)
        : base(loggerFactory, persister)
    {
        _queries = queries;
    }

    public async Task<PagedResult<BeerJson>> GetBeersAsync(Expression<Func<Beer, bool>>? query, int page, int pageSize,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        try
        {
            var beersResult = await _queries.GetByFilterAsync(query, page, pageSize, cancellationToken);
            
            return beersResult.TotalRecords > 0
                ? new PagedResult<BeerJson>(beersResult.Results.Select(r => r.ToJson()), beersResult.Page, beersResult.PageSize, beersResult.TotalRecords)
                : new PagedResult<BeerJson>(Enumerable.Empty<BeerJson>(), 0, 0, 0);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error getting beers");
            throw;
        }
    }
}