namespace BrewUp.Sales.Facade.BindingModels;

public record SalesOrderModel(Guid SalesOrderId, Guid PubId, string PubName, DateTime OrderDate, IEnumerable<SalesOrderLineModel> Rows);