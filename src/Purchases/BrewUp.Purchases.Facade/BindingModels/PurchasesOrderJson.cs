namespace BrewUp.Purchases.Facade.BindingModels;

public record PurchasesOrderJson(Guid Id, Guid SupplierId, DateTime Date, IEnumerable<PurchasesOrderLineJson> Lines);