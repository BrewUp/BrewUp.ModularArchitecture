using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Sagas.Messages.Commands;

public sealed class StartSalesOrderSaga : Command
{
    public readonly OrderId OrderId;
    public readonly IEnumerable<BeerCommittedRow> Rows;

    public StartSalesOrderSaga(OrderId aggregateId, Guid commitId, IEnumerable<BeerCommittedRow> rows) 
        : base(aggregateId, commitId)
    {
        OrderId = aggregateId;
        Rows = rows;
    }
}