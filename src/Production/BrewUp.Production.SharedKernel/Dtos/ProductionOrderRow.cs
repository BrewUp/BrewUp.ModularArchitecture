using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Production.SharedKernel.Dtos;

public record ProductionOrderRow(BeerId BeerId, BeerName BeerName, Quantity Quantity);