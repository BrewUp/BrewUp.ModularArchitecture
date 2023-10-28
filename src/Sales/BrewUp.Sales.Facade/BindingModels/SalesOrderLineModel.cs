using BrewUp.Shared.Dtos;

namespace BrewUp.Sales.Facade.BindingModels;

public record SalesOrderLineModel(Guid BeerId, string BeerName, Quantity Quantity, Price Price);