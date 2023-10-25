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

    public override Task ProcessCommand(CreateSalesOrder command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}