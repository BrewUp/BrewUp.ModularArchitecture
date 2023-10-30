using BrewUp.Shared.Messages;
using BrewUp.Warehouses.ReadModel.Adapters;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Events;

public sealed class BeersBrewedConsumer : IntegrationEventsConsumerBase<BeersBrewed>
{
    protected override IEnumerable<IIntegrationEventHandlerAsync<BeersBrewed>> HandlersAsync { get; }

    public BeersBrewedConsumer(IServiceBus serviceBus, IMufloneConnectionFactory mufloneConnectionFactory,
        ILoggerFactory loggerFactory) : base(mufloneConnectionFactory, loggerFactory)
    {
        HandlersAsync = new List<IIntegrationEventHandlerAsync<BeersBrewed>>
        {
            new BeersBrewedEventHandler(loggerFactory, serviceBus)
        };        
    }
}