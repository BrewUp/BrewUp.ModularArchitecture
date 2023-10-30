namespace BrewUp.Shared.Contracts;

public record ProductionOrderJson(Guid ProductionOrderId, string ProductionOrderNumber, DateTime OrderData,
    IEnumerable<ProductionOrderRowJson> Rows);