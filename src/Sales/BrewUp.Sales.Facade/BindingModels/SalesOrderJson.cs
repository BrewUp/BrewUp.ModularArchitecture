namespace BrewUp.Sales.Facade.BindingModels;

public record SalesOrderJson(Guid Id, Guid CustomerId, DateTime Date, IEnumerable<SalesOrderLineJson> Lines);