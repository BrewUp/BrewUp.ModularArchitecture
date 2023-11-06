using BrewUp.Shared.Messages.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Purchases.Domain.CommandHandlers;

public class CreatePurchaseOrderCommandHandlerAsync : CommandHandlerBaseAsync<CreatePurchaseOrder>
{
    public CreatePurchaseOrderCommandHandlerAsync(IRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
    {
    }

    public override Task ProcessCommand(CreatePurchaseOrder command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}