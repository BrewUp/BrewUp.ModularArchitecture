using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class BeerOriginDiscovered : IntegrationEvent
{
    public readonly BeerId BeerId;
    public readonly HomeBrewed HomeBrewed; 
    
    public BeerOriginDiscovered(BeerId aggregateId, Guid correlationId, HomeBrewed homeBrewed) 
        : base(aggregateId, correlationId)
    {
        BeerId = aggregateId;
        HomeBrewed = homeBrewed;
    }
}