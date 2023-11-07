using BrewUp.Production.Messages.Commands;
using BrewUp.Production.SharedKernel.DomainIds;
using BrewUp.Production.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Messages;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;

namespace BrewUp.Production.ReadModel.Adapters;

public sealed class BeersForSaleCommitted_V2EventHandler : IntegrationEventHandlerAsync<BeersForSaleCommitted_V2>
{
	private readonly IServiceBus _serviceBus;

	public BeersForSaleCommitted_V2EventHandler(ILoggerFactory loggerFactory,
		IServiceBus serviceBus) : base(loggerFactory)
	{
		_serviceBus = serviceBus;
	}

	public override async Task HandleAsync(BeersForSaleCommitted_V2 @event, CancellationToken cancellationToken = new())
	{
		CreateProductionOrder createProductionOrder = new(new ProductionOrderId(@event.OrderId.Value),
			new ProductionOrderNumber(@event.OrderNumber.Value),
			new OrderDate(DateTime.UtcNow),
			@event.CustomerNotes,
			@event.Rows.Select(x =>
				new ProductionOrderRow(new BeerId(x.BeerId), new BeerName(x.BeerName), x.Quantity)));

		await _serviceBus.SendAsync(createProductionOrder, cancellationToken);
	}
}