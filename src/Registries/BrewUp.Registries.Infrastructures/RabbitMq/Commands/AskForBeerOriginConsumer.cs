using BrewUp.Registries.Domain.CommandHandlers;
using BrewUp.Registries.ReadModel.Entities;
using BrewUp.Shared.Messages.Sagas;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Registries.Infrastructures.RabbitMq.Commands;

public sealed class AskForBeerOriginConsumer : CommandConsumerBase<AskForBeerOrigin>
{
    protected override ICommandHandlerAsync<AskForBeerOrigin> HandlerAsync { get; }

    public AskForBeerOriginConsumer(IQueries<Beer> queries, IEventBus eventBus, IRepository repository,
        IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) : base(repository, connectionFactory, loggerFactory)
    {
        HandlerAsync = new AskForBeerOriginCommandHandler(repository, loggerFactory, queries, eventBus);
    }
}