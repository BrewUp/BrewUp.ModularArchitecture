using BrewUp.Production.Domain.CommandHandlers;
using BrewUp.Production.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Production.Infrastructures.RabbitMq.Commands;

public sealed class CompleteProductionOrderConsumer : CommandConsumerBase<CompleteProductionOrder>
{
    protected override ICommandHandlerAsync<CompleteProductionOrder> HandlerAsync { get; }

    public CompleteProductionOrderConsumer(IRepository repository, IMufloneConnectionFactory connectionFactory,
        ILoggerFactory loggerFactory) : base(repository, connectionFactory, loggerFactory)
    {
        HandlerAsync = new CompleteProductionOrderCommandHandler(repository, loggerFactory);
    }
}