using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.EventHandlers;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Events;

public sealed class ProductionOrderCreatedConsumer : DomainEventsConsumerBase<ProductionOrderCreated>
{
    protected override IEnumerable<IDomainEventHandlerAsync<ProductionOrderCreated>> HandlersAsync { get; }

    public ProductionOrderCreatedConsumer(IProductionOrderService productionOrderService,
        IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) 
        : base(connectionFactory, loggerFactory)
    {
        HandlersAsync = new List<IDomainEventHandlerAsync<ProductionOrderCreated>>
        {
            new ProductionOrderCreatedEventHandler(loggerFactory, productionOrderService)
        };
    }
}