using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.EventHandlers;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Events;

public sealed class BeerAvailabilityLoadedConsumer : DomainEventsConsumerBase<BeerAvailabilityLoaded>
{
    protected override IEnumerable<IDomainEventHandlerAsync<BeerAvailabilityLoaded>> HandlersAsync { get; }

    public BeerAvailabilityLoadedConsumer(IBeerAvailabilityService beerAvailabilityService,
        IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) : base(connectionFactory,
        loggerFactory)
    {
        HandlersAsync = new List<IDomainEventHandlerAsync<BeerAvailabilityLoaded>>
        {
            new BeerAvailabilityLoadedEventHandlerAsync(loggerFactory, beerAvailabilityService)
        };   
    }
}