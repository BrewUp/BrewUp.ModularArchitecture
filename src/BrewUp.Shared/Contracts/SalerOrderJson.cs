namespace BrewUp.Shared.Contracts;

public record SalerOrderJson(Guid SalesOrderId, string SalesOrderNumber, Guid PubId, string PubName, DateTime OrderDate,
    IEnumerable<SalesOrderLineJson> Rows);
