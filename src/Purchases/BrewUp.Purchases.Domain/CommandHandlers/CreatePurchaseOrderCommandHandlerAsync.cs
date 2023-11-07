using Brewup.Purchases.Domain.Entities;
using BrewUp.Shared.Messages.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Purchases.Domain.CommandHandlers;

public class CreatePurchaseOrderCommandHandlerAsync : CommandHandlerBaseAsync<CreatePurchaseOrder>
{
    public CreatePurchaseOrderCommandHandlerAsync(IRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
    {
    }

    public override async Task ProcessCommand(CreatePurchaseOrder command, CancellationToken cancellationToken = default)
    {
        var aggregate = PurchaseOrder.Create(command.PurchaseOrderId, command.MessageId, command.SupplierId, command.OrderDate, command.Rows);
        await Repository.SaveAsync(aggregate, Guid.NewGuid());
    }
}