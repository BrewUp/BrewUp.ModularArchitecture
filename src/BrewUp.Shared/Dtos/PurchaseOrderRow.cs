using BrewUp.Shared.DomainIds;

namespace BrewUp.Shared.Dtos;

public record PurchaseOrderRow(BeerId BeerId, BeerName BeerName, Quantity Quantity, Cost Cost);