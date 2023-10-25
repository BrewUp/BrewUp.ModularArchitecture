using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Sales.SharedKernel.Dtos;

public record SalesOrderLineDto(ProductId ProductId, ProductName ProductName, Quantity Quantity, Price Price);