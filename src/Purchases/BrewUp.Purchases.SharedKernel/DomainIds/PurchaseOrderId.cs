using Muflone.Core;

namespace BrewUp.Purchases.SharedKernel.DomainIds;

public class PurchaseOrderId : DomainId
{
	public PurchaseOrderId(Guid value) : base(value)
	{
	}
}