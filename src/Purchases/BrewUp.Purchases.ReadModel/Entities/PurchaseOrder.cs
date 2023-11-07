using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace Brewup.Purchases.ReadModel.Entities;

public class PurchaseOrder : EntityBase
{
	public DateTime Date { get; private set; }
	public IEnumerable<PurchaseOrderRow> Rows { get; private set; }
	public SupplierId SupplierId { get; private set; }
	public Status Status { get; set; }

	public static PurchaseOrder Create(PurchaseOrderId purchaseOrderId, OrderDate date, IEnumerable<PurchaseOrderRow> rows,
		SupplierId supplierId)
	{
		return new PurchaseOrder(purchaseOrderId, date, rows, supplierId);
	}

	private PurchaseOrder(PurchaseOrderId purchaseOrderId, OrderDate date, IEnumerable<PurchaseOrderRow> rows,
		SupplierId supplierId)
	{
		Date = date.Value;
		Rows = rows;
		SupplierId = supplierId;
		Id = purchaseOrderId.Value.ToString();
		Status = Status.Created;
	}
}