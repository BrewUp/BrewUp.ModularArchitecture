using BrewUp.Shared.DomainIds;

namespace BrewUp.Shared.Dtos;

public record BrewedRow(BeerId BeerId, BeerName BeerName, Quantity Quantity);