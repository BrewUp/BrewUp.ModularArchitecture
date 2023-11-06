using BrewUp.Sagas.Messages.Commands;
using BrewUp.Sagas.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;
using Muflone.Saga;
using Muflone.Saga.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Saga.Consumers;

namespace BrewUp.Sagas.Infrastructures.RabbitMq.Commands;

public sealed class StartSalesOrderSagaConsumer : SagaStartedByConsumerBase<StartSalesOrderSaga>
{
    protected override ISagaStartedByAsync<StartSalesOrderSaga> HandlerAsync { get; }
    
    public StartSalesOrderSagaConsumer(IServiceBus serviceBus, ISagaRepository sagaRepository, IRepository repository,
        IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) : base(repository, connectionFactory,
        loggerFactory)
    {
        HandlerAsync = new SalesOrderSaga(serviceBus, sagaRepository, loggerFactory);
    }
}