using System.Linq.Expressions;
using BrewUp.Sales.ReadModel.Entities;
using BrewUp.Shared.Entities;
using BrewUp.Shared.ReadModel;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BrewUp.Sales.ReadModel.Queries;

public sealed class SalesOrderQueries : IQueries<SalesOrder>
{
    private readonly IMongoDatabase _database;

    public SalesOrderQueries(IMongoDatabase database)
    {
        _database = database;
    }
    
    public async Task<SalesOrder> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var collection = _database.GetCollection<SalesOrder>(nameof(SalesOrder));
        var filter = Builders<SalesOrder>.Filter.Eq("_id", id);
        return (await collection.CountDocumentsAsync(filter, cancellationToken: cancellationToken) > 0
            ? (await collection.FindAsync(filter, cancellationToken: cancellationToken)).First()
            : null)!;
    }

    public async Task<PagedResult<SalesOrder>> GetByFilterAsync(Expression<Func<SalesOrder, bool>>? query, int page, int pageSize, CancellationToken cancellationToken)
    {
        if (--page < 0)
            page = 0;

        var collection = _database.GetCollection<SalesOrder>(nameof(SalesOrder));
        var queryable = query != null
            ? collection.AsQueryable().Where(query)
            : collection.AsQueryable();

        var count = await queryable.CountAsync(cancellationToken: cancellationToken);
        var results = await queryable.Skip(page * pageSize).Take(pageSize).ToListAsync(cancellationToken: cancellationToken);

        return new PagedResult<SalesOrder>(results, page, pageSize, count);
    }
}