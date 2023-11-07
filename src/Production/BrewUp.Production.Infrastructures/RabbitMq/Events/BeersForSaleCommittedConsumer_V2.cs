using BrewUp.Production.ReadModel.Adapters;
using BrewUp.Shared.Messages;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Production.Infrastructures.RabbitMq.Events;

public sealed class BeersForSaleCommitted_V2Consumer : IntegrationEventsConsumerBase<BeersForSaleCommitted_V2>
{
	protected override IEnumerable<IIntegrationEventHandlerAsync<BeersForSaleCommitted_V2>> HandlersAsync { get; }

	public BeersForSaleCommitted_V2Consumer(IServiceBus serviceBus,
		IMufloneConnectionFactory mufloneConnectionFactory,
		ILoggerFactory loggerFactory) : base(mufloneConnectionFactory, loggerFactory)
	{
		HandlersAsync = new List<IIntegrationEventHandlerAsync<BeersForSaleCommitted_V2>>
		{
			new BeersForSaleCommitted_V2EventHandler(loggerFactory, serviceBus)
		};
	}
}