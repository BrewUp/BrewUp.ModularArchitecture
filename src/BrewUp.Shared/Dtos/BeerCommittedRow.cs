namespace BrewUp.Shared.Dtos;

public record BeerCommittedRow(Guid BeerId, string BeerName, Quantity Quantity);