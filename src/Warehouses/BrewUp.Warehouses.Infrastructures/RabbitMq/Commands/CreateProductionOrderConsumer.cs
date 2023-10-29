using BrewUp.Warehouses.Domain.CommandHandlers;
using BrewUp.Warehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Commands;

public sealed class CreateProductionOrderConsumer : CommandConsumerBase<CreateProductionOrder>
{
    protected override ICommandHandlerAsync<CreateProductionOrder> HandlerAsync { get; }
    
    public CreateProductionOrderConsumer(IRepository repository, IMufloneConnectionFactory connectionFactory,
        ILoggerFactory loggerFactory) : base(repository, connectionFactory, loggerFactory)
    {
        HandlerAsync = new CreateProductionOrderCommandHandler(repository, loggerFactory);
    }
}