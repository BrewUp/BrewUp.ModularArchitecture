using System.Linq.Expressions;
using BrewUp.Production.ReadModel.Entities;
using BrewUp.Shared.Entities;
using BrewUp.Shared.ReadModel;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BrewUp.Production.ReadModel.Queries;

public sealed class ProductionOrderQueries : IQueries<ProductionOrder>
{
    private readonly IMongoClient _mongoClient;
    private IMongoDatabase _database;
    
    public string DatabaseName { get; private set; }

    public ProductionOrderQueries(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }
    
    public void SetDatabaseName(string databaseName)
    {
        DatabaseName = databaseName;
        _database = _mongoClient.GetDatabase(databaseName);
    }
    
    public async Task<ProductionOrder> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var collection = _database.GetCollection<ProductionOrder>(nameof(ProductionOrder));
        var filter = Builders<ProductionOrder>.Filter.Eq("_id", id);
        return (await collection.CountDocumentsAsync(filter, cancellationToken: cancellationToken) > 0
            ? (await collection.FindAsync(filter, cancellationToken: cancellationToken)).First()
            : null)!;
    }

    public async Task<PagedResult<ProductionOrder>> GetByFilterAsync(Expression<Func<ProductionOrder, bool>>? query, int page, int pageSize, CancellationToken cancellationToken)
    {
        if (--page < 0)
            page = 0;

        var collection = _database.GetCollection<ProductionOrder>(nameof(ProductionOrder));
        var queryable = query != null
            ? collection.AsQueryable().Where(query)
            : collection.AsQueryable();

        var count = await queryable.CountAsync(cancellationToken: cancellationToken);
        var results = await queryable.Skip(page * pageSize).Take(pageSize).ToListAsync(cancellationToken: cancellationToken);

        return new PagedResult<ProductionOrder>(results, page, pageSize, count);
    }
}