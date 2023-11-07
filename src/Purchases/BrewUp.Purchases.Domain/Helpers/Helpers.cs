using Brewup.Purchases.Domain.Entities;
using BrewUp.Shared.Dtos;
using Cost = Brewup.Purchases.Domain.Entities.Cost;
using Quantity = Brewup.Purchases.Domain.Entities.Quantity;

namespace BrewUp.Purchases.Domain.Helpers;

public static class Helpers
{
	public static IEnumerable<PurchaseOrderRow> ToDtos(this IEnumerable<PurchaseOrderLine> lines)
	{
		return lines.Select(x => new PurchaseOrderRow(x.BeerId, x.BeerName,
			new BrewUp.Shared.Dtos.Quantity(x.Quantity.Value, x.Quantity.UnitOfMeasure), 
			new BrewUp.Shared.Dtos.Cost(x.Cost.Value, x.Cost.Currency)));
	}

	public static IEnumerable<PurchaseOrderLine> ToEntities(this IEnumerable<PurchaseOrderRow> lines)
	{
		return lines.Select(x => new Brewup.Purchases.Domain.Entities.PurchaseOrderLine(
			x.BeerId,
			x.BeerName,
			new Quantity(x.Quantity.Value, x.Quantity.UnitOfMeasure),
			new Cost(x.Cost.Value, x.Cost.Currency)));
	}
}