using BrewUp.Sagas.Sagas;
using BrewUp.Shared.Messages.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;
using Muflone.Saga;
using Muflone.Saga.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Saga.Consumers;

namespace BrewUp.Sagas.Infrastructures.RabbitMq.Events;

public sealed class BeersOriginDiscoveredConsumer : SagaEventConsumerBase<BeerOriginDiscovered>
{
    protected override ISagaEventHandlerAsync<BeerOriginDiscovered> HandlerAsync { get; }

    public BeersOriginDiscoveredConsumer(IServiceBus serviceBus, ISagaRepository sagaRepository,
        IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) : base(connectionFactory,
        loggerFactory)
    {
        HandlerAsync = new SalesOrderSaga(serviceBus, sagaRepository, loggerFactory);
    }
}