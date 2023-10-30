using Muflone.Core;

namespace BrewUp.Production.SharedKernel.DomainIds;

public sealed class ProductionOrderId : DomainId
{
    public ProductionOrderId(Guid value) : base(value)
    {
    }
}