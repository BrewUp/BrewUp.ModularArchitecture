using BrewUp.Shared.Messages.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Commands;

public sealed class AskForBeerAvailabilityConsumer : CommandConsumerBase<AskForBeerAvailability>
{
    protected override ICommandHandlerAsync<AskForBeerAvailability> HandlerAsync { get; }
    
    public AskForBeerAvailabilityConsumer(IRepository repository, IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) : base(repository, connectionFactory, loggerFactory)
    {
    }

    
}