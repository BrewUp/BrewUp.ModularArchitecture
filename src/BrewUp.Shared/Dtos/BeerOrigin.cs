using BrewUp.Shared.DomainIds;

namespace BrewUp.Shared.Dtos;

public record BeerOrigin(BeerId BeerId, BeerName BeerName, HomeBrewed HomeBrewed);