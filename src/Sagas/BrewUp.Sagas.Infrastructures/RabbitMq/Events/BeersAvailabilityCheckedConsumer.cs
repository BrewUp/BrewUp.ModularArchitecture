using BrewUp.Sagas.Sagas;
using BrewUp.Shared.Messages.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;
using Muflone.Saga;
using Muflone.Saga.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Saga.Consumers;

namespace BrewUp.Sagas.Infrastructures.RabbitMq.Events;

public sealed class BeersAvailabilityCheckedConsumer : SagaEventConsumerBase<BeerAvailabilityCommunicated>
{
    protected override ISagaEventHandlerAsync<BeerAvailabilityCommunicated> HandlerAsync { get; }

    public BeersAvailabilityCheckedConsumer(IServiceBus serviceBus, ISagaRepository sagaRepository,
        IRepository repository, IMufloneConnectionFactory mufloneConnectionFactory,
        ILoggerFactory loggerFactory) : base(mufloneConnectionFactory, loggerFactory)
    {
        HandlerAsync = new SalesOrderSaga(serviceBus, sagaRepository, loggerFactory);
    }
}