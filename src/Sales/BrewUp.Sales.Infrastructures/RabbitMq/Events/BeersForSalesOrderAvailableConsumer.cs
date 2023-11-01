using BrewUp.Sales.ReadModel.Adapters;
using BrewUp.Shared.Messages;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Sales.Infrastructures.RabbitMq.Events;

public sealed class BeersForSalesOrderAvailableConsumer : IntegrationEventsConsumerBase<BeersForSalesOrderAvailable>
{
    protected override IEnumerable<IIntegrationEventHandlerAsync<BeersForSalesOrderAvailable>> HandlersAsync { get; }

    public BeersForSalesOrderAvailableConsumer(IServiceBus serviceBus,
        IMufloneConnectionFactory mufloneConnectionFactory, ILoggerFactory loggerFactory) : base(
        mufloneConnectionFactory, loggerFactory)
    {
        HandlersAsync = new List<IIntegrationEventHandlerAsync<BeersForSalesOrderAvailable>>
        {
            new BeersForSalesOrderAvailableEventHandler(loggerFactory, serviceBus)
        };
    }
}