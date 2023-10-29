using BrewUp.Sales.Domain.Entities;
using BrewUp.Sales.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Sales.Domain.CommandHandlers;

public sealed class CreateSalesOrderCommandHandlerAsync : CommandHandlerBaseAsync<CreateSalesOrder>
{
    public CreateSalesOrderCommandHandlerAsync(IRepository repository, ILoggerFactory loggerFactory) 
        : base(repository, loggerFactory)
    {
        
    }

    public override async Task ProcessCommand(CreateSalesOrder command, CancellationToken cancellationToken = default)
    {
        var aggregate =
            SalesOrder.CreateSalesOrder(command.SalesOrderId, command.SalesOrderNumber, command.PubId, command.PubName, command.OrderDate, command.Lines);
        await Repository.SaveAsync(aggregate, Guid.NewGuid());
    }
}