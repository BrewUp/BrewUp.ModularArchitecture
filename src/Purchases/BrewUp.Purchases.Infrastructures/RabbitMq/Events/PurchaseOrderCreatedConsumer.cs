using BrewUp.Purchases.Messages.Events;
using BrewUp.Purchases.ReadModel.EventHandlers;
using BrewUp.Purchases.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Purchases.Infrastructures.RabbitMq.Events;

public sealed class PurchaseOrderCreatedConsumer : DomainEventsConsumerBase<PurchaseOrderCreated>
{
    protected override IEnumerable<IDomainEventHandlerAsync<PurchaseOrderCreated>> HandlersAsync { get; }

    public PurchaseOrderCreatedConsumer(IPurchaseOrderService purchaseOrderService,
        IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) : base(connectionFactory,
        loggerFactory)
    {
        HandlersAsync = new List<IDomainEventHandlerAsync<PurchaseOrderCreated>>
        {
            new PurchaseOrderCreatedEventHandler(loggerFactory, purchaseOrderService)
        };
    }
}