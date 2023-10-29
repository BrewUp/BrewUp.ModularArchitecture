using BrewUp.Shared.Dtos;

namespace BrewUp.Shared.Contracts;

public record BeerCommittedRow(Guid BeerId, string BeerName, Quantity Quantity);