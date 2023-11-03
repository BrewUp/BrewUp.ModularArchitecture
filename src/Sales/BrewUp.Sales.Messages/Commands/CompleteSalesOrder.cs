using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Sales.Messages.Commands;

public sealed class CompleteSalesOrder : Command
{
    public readonly SalesOrderId SalesOrderId;
    public readonly IEnumerable<BrewedRow> Rows;
    
    public CompleteSalesOrder(SalesOrderId aggregateId, IEnumerable<BrewedRow> rows) : base(aggregateId)
    {
        SalesOrderId = aggregateId;
        Rows = rows;
    }
}