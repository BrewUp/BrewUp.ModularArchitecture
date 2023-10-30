namespace BrewUp.Shared.Contracts;

public record SalesOrderJson(Guid SalesOrderId, string SalesOrderNumber, Guid PubId, string PubName, DateTime OrderDate,
    IEnumerable<SalesOrderRowJson> Rows);
