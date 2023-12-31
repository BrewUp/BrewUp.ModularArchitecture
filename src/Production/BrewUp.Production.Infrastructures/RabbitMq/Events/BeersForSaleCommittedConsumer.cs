﻿using BrewUp.Production.ReadModel.Adapters;
using BrewUp.Shared.Messages;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Production.Infrastructures.RabbitMq.Events;

public sealed class BeersForSaleCommittedConsumer : IntegrationEventsConsumerBase<BeersForSaleCommitted>
{
    protected override IEnumerable<IIntegrationEventHandlerAsync<BeersForSaleCommitted>> HandlersAsync { get; }

    public BeersForSaleCommittedConsumer(IServiceBus serviceBus,
        IMufloneConnectionFactory mufloneConnectionFactory,
        ILoggerFactory loggerFactory) : base(mufloneConnectionFactory, loggerFactory)
    {
        HandlersAsync = new List<IIntegrationEventHandlerAsync<BeersForSaleCommitted>>
        {
            new BeersForSaleCommittedEventHandler(loggerFactory, serviceBus)
        };
    }
}