using BrewUp.Sales.Domain.Entities;
using BrewUp.Sales.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Sales.Domain.CommandHandlers;

public sealed class CompleteSalesOrderCommandHandler : CommandHandlerBaseAsync<CompleteSalesOrder>
{
    public CompleteSalesOrderCommandHandler(IRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
    {
    }

    public override async Task ProcessCommand(CompleteSalesOrder command, CancellationToken cancellationToken = default)
    {
        var aggregate = await Repository.GetByIdAsync<SalesOrder>(command.AggregateId.Value);
        aggregate.Complete(command.SalesOrderId, command.Rows);

        await Repository.SaveAsync(aggregate, Guid.NewGuid());
    }
}