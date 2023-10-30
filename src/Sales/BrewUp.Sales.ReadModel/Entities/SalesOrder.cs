using BrewUp.Sales.ReadModel.Helpers;
using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.Sales.ReadModel.Entities;

public class SalesOrder : EntityBase
{
    public string OrderNumber { get; private set; } = string.Empty;
    
    public string PubId { get; private set; } = string.Empty;
    public string PubName { get; private set; } = string.Empty;
    
    public DateTime OrderDate { get; private set; } = DateTime.MinValue;
    
    public IEnumerable<SalesOrderRow> Rows { get; private set; } = Enumerable.Empty<SalesOrderRow>();
    
    protected SalesOrder()
    {}

    public static SalesOrder CreateSalesOrder(SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber, PubId pubId,
        PubName pubName, OrderDate orderDate, IEnumerable<SalesOrderRowDto> rows) => new(salesOrderId.Value.ToString(),
        salesOrderNumber.Value, pubId.Value.ToString(), pubName.Value, orderDate.Value, rows.ToReadModelEntities());
    
    private SalesOrder(string salesOrderId, string salesOrderNumber, string pubId, string pubName, DateTime orderDate, IEnumerable<SalesOrderRow> rows)
    {
        Id = salesOrderId;
        OrderNumber = salesOrderNumber;
        PubId = pubId;
        PubName = pubName;
        OrderDate = orderDate;
        Rows = rows;
    }
    
    public SalesOrderJson ToJson() => new(Guid.Parse(Id), OrderNumber, Guid.Parse(PubId), PubName, OrderDate, Rows.Select(r => r.ToJson));
}