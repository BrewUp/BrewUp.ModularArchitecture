using BrewUp.Shared.DomainIds;

namespace BrewUp.Shared.Dtos;

public record BeerSalesOrderSagaRow(BeerId BeerId, BeerName BeerName, Quantity Quantity, Availability Availability, HomeBrewed HomeBrewed);