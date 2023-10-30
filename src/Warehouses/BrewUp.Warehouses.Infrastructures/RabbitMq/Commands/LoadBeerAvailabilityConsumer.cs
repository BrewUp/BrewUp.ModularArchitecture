using BrewUp.Warehouses.Domain.CommandHandlers;
using BrewUp.Warehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Commands;

public sealed class LoadBeerAvailabilityConsumer : CommandConsumerBase<LoadBeerAvailability>
{
    protected override ICommandHandlerAsync<LoadBeerAvailability> HandlerAsync { get; }

    public LoadBeerAvailabilityConsumer(IRepository repository, IMufloneConnectionFactory connectionFactory,
        ILoggerFactory loggerFactory) : base(repository, connectionFactory, loggerFactory)
    {
        HandlerAsync = new LoadBeerAvailabilityCommandHandlerAsync(repository, loggerFactory);
    }
}