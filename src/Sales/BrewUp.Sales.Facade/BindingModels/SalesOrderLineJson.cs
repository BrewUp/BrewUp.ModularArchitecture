using BrewUp.Shared.Dtos;

namespace BrewUp.Sales.Facade.BindingModels;

public record SalesOrderLineJson(Guid BeerId, string BeerName, Quantity Quantity, Price Price);