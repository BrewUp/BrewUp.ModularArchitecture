using BrewUp.Sales.Messages.Events;
using BrewUp.Sales.ReadModel.EventHandlers;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Sales.Infrastructures.RabbitMq.Events;

public sealed class SalesOrderCreatedConsumer : DomainEventsConsumerBase<SalesOrderCreated>
{
    protected override IEnumerable<IDomainEventHandlerAsync<SalesOrderCreated>> HandlersAsync { get; }

    public SalesOrderCreatedConsumer(IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) : base(connectionFactory, loggerFactory)
    {
        HandlersAsync = new List<DomainEventHandlerAsync<SalesOrderCreated>>
        {
            new SalesOrderCreatedEventHandlerAsync(loggerFactory)
        };
    }
}