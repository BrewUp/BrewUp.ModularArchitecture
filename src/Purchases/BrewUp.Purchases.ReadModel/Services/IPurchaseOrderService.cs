using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Purchases.ReadModel.Services;

public interface IPurchaseOrderService
{
	Task CreatePurchaseOrderAsync(PurchaseOrderId purchaseOrderId, OrderDate date, IEnumerable<PurchaseOrderRow> rows,
		SupplierId supplierId, CancellationToken cancellationToken);
	// Task UpdateStatusToCompleteAsync(PurchaseOrderId purchaseOrderId, CancellationToken cancellationToken);
}