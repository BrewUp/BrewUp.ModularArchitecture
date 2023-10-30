using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Sales.SharedKernel.Dtos;

public record SalesOrderRowDto(BeerId BeerId, BeerName BeerName, Quantity Quantity, Price Price);