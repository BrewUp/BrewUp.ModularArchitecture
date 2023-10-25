using Muflone.Core;

namespace BrewUp.Sales.SharedKernel.DomainIds;

public sealed class SalesOrderId : DomainId
{
    public SalesOrderId(Guid value) : base(value)
    {
    }
}