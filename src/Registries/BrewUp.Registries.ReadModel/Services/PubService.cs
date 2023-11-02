using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;

namespace BrewUp.Registries.ReadModel.Services;

public sealed class PubService : ServiceBase, IBeerService
{
    private readonly IQueries<SalesOrder> _queries;
    
    public PubService(ILoggerFactory loggerFactory, IPersister persister, IQueries<SalesOrder> queries) : base(loggerFactory, persister)
    {
        _queries = queries;
    }
    
    public PubService(ILoggerFactory loggerFactory, IPersister persister) : base(loggerFactory, persister)
    {
    }

    public async Task CreateBeerAsync(BeerId beerId, BeerName beerName, BeerType beerType, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<BeerJson>> GetBeersAsync(object o, int i, int i1, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}