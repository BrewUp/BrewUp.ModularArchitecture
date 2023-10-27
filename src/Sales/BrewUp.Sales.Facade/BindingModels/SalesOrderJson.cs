namespace BrewUp.Sales.Facade.BindingModels;

public record SalesOrderJson(Guid SalesOrderId, Guid CustomerId, string CustomerName, DateTime OrderDate, IEnumerable<SalesOrderLineJson> Rows);