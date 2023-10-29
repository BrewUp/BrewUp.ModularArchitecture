using Muflone.Core;

namespace BrewUp.Warehouses.SharedKernel.DomainIds;

public sealed class ProductionOrderId : DomainId
{
    public ProductionOrderId(Guid value) : base(value)
    {
    }
}