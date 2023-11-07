using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Core;

namespace Brewup.Purchases.Domain.Entities;

public class PurchaseOrderLine : Entity
{
	public BeerId BeerId { get; }
	public BeerName BeerName { get; }
	public Quantity Quantity { get; }
	public Cost Cost { get; }

	public PurchaseOrderLine(BeerId beerId, BeerName beerName, Quantity quantity, Cost cost)
	{
		BeerId = beerId;
		BeerName = beerName;
		Quantity = quantity;
		Cost = cost;
	}
}