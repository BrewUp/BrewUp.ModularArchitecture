using Muflone.Core;

namespace BrewUp.Shared.DomainIds;

public sealed class PubId : DomainId
{
    public PubId(Guid value) : base(value)
    {
    }
}