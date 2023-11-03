using BrewUp.Sales.Messages.Events;
using BrewUp.Sales.ReadModel.EventHandlers;
using BrewUp.Sales.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Sales.Infrastructures.RabbitMq.Events;

public sealed class SalesOrderCompletedConsumer : DomainEventsConsumerBase<SalesOrderCompleted>
{
    protected override IEnumerable<IDomainEventHandlerAsync<SalesOrderCompleted>> HandlersAsync { get; }

    public SalesOrderCompletedConsumer(ISalesOrderService salesOrderService,
        IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) : base(connectionFactory,
        loggerFactory)
    {
        HandlersAsync = new List<IDomainEventHandlerAsync<SalesOrderCompleted>>
        {
            new SalesOrderCompletedEventHandler(loggerFactory, salesOrderService)
        };
    }
}