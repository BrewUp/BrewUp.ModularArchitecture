namespace BrewUp.Shared.BindingModels;

public class SalerOrderJson
{
    public Guid SalesOrderId { get; set; } = Guid.Empty;
    public Guid PubId { get; set; } = Guid.Empty;
    public string PubName { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; } = DateTime.MinValue;
    
    public IEnumerable<SalesOrderLineJson> Rows { get; set; } = Enumerable.Empty<SalesOrderLineJson>();
}