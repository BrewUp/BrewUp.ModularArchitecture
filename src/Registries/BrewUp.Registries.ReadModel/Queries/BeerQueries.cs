using System.Linq.Expressions;
using BrewUp.Registries.ReadModel.Entities;
using BrewUp.Shared.Entities;
using BrewUp.Shared.ReadModel;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BrewUp.Registries.ReadModel.Queries;

public sealed class BeerQueries : IQueries<Beer>
{
    private readonly IMongoClient _mongoClient;
    private IMongoDatabase _database;
    
    public string DatabaseName { get; private set; }

    public BeerQueries(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }

    public void SetDatabaseName(string databaseName)
    {
        DatabaseName = databaseName;
        _database = _mongoClient.GetDatabase(databaseName);
    }

    public async Task<Beer> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var collection = _database.GetCollection<Beer>(nameof(Beer));
        var filter = Builders<Beer>.Filter.Eq("_id", id);
        return (await collection.CountDocumentsAsync(filter, cancellationToken: cancellationToken) > 0
            ? (await collection.FindAsync(filter, cancellationToken: cancellationToken)).First()
            : null)!;
    }

    public async Task<PagedResult<Beer>> GetByFilterAsync(Expression<Func<Beer, bool>>? query, int page, int pageSize, CancellationToken cancellationToken)
    {
        if (--page < 0)
            page = 0;

        var collection = _database.GetCollection<Beer>(nameof(Beer));
        var queryable = query != null
            ? collection.AsQueryable().Where(query)
            : collection.AsQueryable();

        var count = await queryable.CountAsync(cancellationToken: cancellationToken);
        var results = await queryable.Skip(page * pageSize).Take(pageSize).ToListAsync(cancellationToken: cancellationToken);

        return new PagedResult<Beer>(results, page, pageSize, count);
    }
}