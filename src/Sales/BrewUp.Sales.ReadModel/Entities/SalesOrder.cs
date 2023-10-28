using BrewUp.Sales.ReadModel.Helpers;
using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.Sales.ReadModel.Entities;

public class SalesOrder : EntityBase
{
    public string PubId { get; private set; } = string.Empty;
    public string PubName { get; private set; } = string.Empty;
    
    public DateTime OrderDate { get; private set; } = DateTime.MinValue;
    
    public IEnumerable<SalesOrderRow> Rows { get; private set; } = Enumerable.Empty<SalesOrderRow>();
    
    protected SalesOrder()
    {}

    public static SalesOrder CreateSalesOrder(SalesOrderId salesOrderId, PubId pubId, PubName pubName,
        OrderDate orderDate, IEnumerable<SalesOrderLineDto> rows)
        => new(salesOrderId.Value.ToString(), pubId.Value.ToString(), pubName.Value, orderDate.Value, rows.ToReadModelEntities());
    
    private SalesOrder(string salesOrderId, string pubId, string pubName, DateTime orderDate, IEnumerable<SalesOrderRow> rows)
    {
        Id = salesOrderId;
        PubId = pubId;
        PubName = pubName;
        OrderDate = orderDate;
        Rows = rows;
    }
}