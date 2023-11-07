using BrewUp.Purchases.Domain.Helpers;
using BrewUp.Purchases.Messages.Events;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Core;

namespace Brewup.Purchases.Domain.Entities;

public class PurchaseOrder : AggregateRoot
{
	private OrderDate _date;
	private IEnumerable<PurchaseOrderLine> _rows;
	private Status _status;

	//Called when loaded from the event store
	protected PurchaseOrder()
	{
	}

	internal static PurchaseOrder Create(PurchaseOrderId id, Guid correlationId, SupplierId supplierId, OrderDate date,
		IEnumerable<PurchaseOrderRow> lines)
	{
		return new PurchaseOrder(id, correlationId, supplierId, date, lines);
	}

	private PurchaseOrder(PurchaseOrderId id, Guid correlationId, SupplierId supplierId, OrderDate date,
		IEnumerable<PurchaseOrderRow> rows)
	{
		RaiseEvent(new PurchaseOrderCreated(id, correlationId, supplierId, date, rows));
	}

	private void Apply(PurchaseOrderCreated @event)
	{
		Id = @event.AggregateId;
		_status = Status.Created;
		_rows = @event.Rows.ToEntities();
	}

	// public void Complete()
	// {
	// 	if (!_status.Equals(Status.Completed))
	// 		RaiseEvent(new PurchaseOrderStatusChangedToComplete((PurchaseOrderId)Id, _lines.ToDtos()));
	// }
	//
	// private void Apply(PurchaseOrderStatusChangedToComplete @event)
	// {
	// 	_status = Status.Completed;
	// }
}