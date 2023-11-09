using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.EventHandlers;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Events;

public sealed class BeerAvailabilityCheckedConsumer : DomainEventsConsumerBase<BeerAvailabilityChecked>
{
    protected override IEnumerable<IDomainEventHandlerAsync<BeerAvailabilityChecked>> HandlersAsync { get; }

    public BeerAvailabilityCheckedConsumer(IEventBus eventBus, IMufloneConnectionFactory connectionFactory,
        ILoggerFactory loggerFactory) : base(connectionFactory, loggerFactory)
    {
        HandlersAsync = new List<IDomainEventHandlerAsync<BeerAvailabilityChecked>>
        {
            new BeerAvailabilityCheckedEventHandler(loggerFactory, eventBus)
        };
    }
}