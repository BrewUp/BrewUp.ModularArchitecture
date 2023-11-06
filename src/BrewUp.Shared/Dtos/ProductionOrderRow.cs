using BrewUp.Shared.DomainIds;

namespace BrewUp.Shared.Dtos;

public record ProductionOrderRow(BeerId BeerId, BeerName BeerName, Quantity Quantity);