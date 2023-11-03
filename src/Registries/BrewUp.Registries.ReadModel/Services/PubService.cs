using System.Linq.Expressions;
using BrewUp.Registries.ReadModel.Entities;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;

namespace BrewUp.Registries.ReadModel.Services;

public sealed class PubService : ServiceBase, IPubService
{
    private readonly IQueries<Pub> _queries;
    
    public PubService(ILoggerFactory loggerFactory, IPersister persister, IQueries<Pub> queries) : base(loggerFactory, persister)
    {
        _queries = queries;
        _queries.SetDatabaseName("BrewUp_Registries");
    }

    public async Task<string> CreatePubAsync(PubId pubId, PubName pubName, CancellationToken cancellationToken)
    {
        try
        {
            var pub = Pub.CreatePub(pubId, pubName);
            await Persister.InsertAsync(pub, cancellationToken);

            return pubId.Value.ToString();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error creating pub");
            throw;
        }
    }

    public async Task<PagedResult<PubJson>> GetPubsAsync(Expression<Func<Pub, bool>>? query, int page, int pageSize, CancellationToken cancellationToken)
    {
        try
        {
            var pubsResult = await _queries.GetByFilterAsync(query, page, pageSize, cancellationToken);
            
            return pubsResult.TotalRecords > 0
                ? new PagedResult<PubJson>(pubsResult.Results.Select(r => r.ToJson()), pubsResult.Page, pubsResult.PageSize, pubsResult.TotalRecords)
                : new PagedResult<PubJson>(Enumerable.Empty<PubJson>(), 0, 0, 0);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error reading pubs");
            throw;
        }
    }
}