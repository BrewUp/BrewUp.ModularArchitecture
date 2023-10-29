using BrewUp.Warehouses.Domain.Entities;
using BrewUp.Warehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Warehouses.Domain.CommandHandlers;

public sealed class CreateProductionOrderCommandHandler : CommandHandlerBaseAsync<CreateProductionOrder>
{
    public CreateProductionOrderCommandHandler(IRepository repository, ILoggerFactory loggerFactory) 
        : base(repository, loggerFactory)
    {
    }

    public override async Task ProcessCommand(CreateProductionOrder command, CancellationToken cancellationToken = default)
    {
        var aggregate = ProductionOrder.CreateProductionOrder(command.ProductionOrderId, command.ProductionOrderNumber,
            command.OrderDate, command.Rows);
        await Repository.SaveAsync(aggregate, Guid.NewGuid());
    }
}