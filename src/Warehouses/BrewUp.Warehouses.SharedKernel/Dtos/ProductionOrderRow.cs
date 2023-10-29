using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Warehouses.SharedKernel.Dtos;

public record ProductionOrderRow(BeerId BeerId, BeerName BeerName, Quantity Quantity);