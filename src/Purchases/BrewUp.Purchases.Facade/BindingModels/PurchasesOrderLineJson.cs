using BrewUp.Shared.Dtos;

namespace BrewUp.Purchases.Facade.BindingModels;

public record PurchasesOrderLineJson(Guid BeerId, string BeerName, Quantity Quantity, Price Price);
