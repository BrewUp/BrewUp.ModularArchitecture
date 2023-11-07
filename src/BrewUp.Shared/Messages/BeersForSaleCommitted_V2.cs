using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages;

public sealed class BeersForSaleCommitted_V2 : IntegrationEvent
{
	public readonly OrderId OrderId;
	public readonly OrderNumber OrderNumber;

	public readonly IEnumerable<BeerCommittedRow> Rows;
	public readonly string CustomerNotes;

	public BeersForSaleCommitted_V2(OrderId aggregateId, OrderNumber orderNumber, string customerNotes,
		IEnumerable<BeerCommittedRow> rows) : base(aggregateId)
	{
		OrderId = aggregateId;
		OrderNumber = orderNumber;

		Rows = rows;

		CustomerNotes = customerNotes;
	}
}