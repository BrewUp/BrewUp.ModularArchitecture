using BrewUp.Shared.DomainIds;
using Muflone.Messages.Commands;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class AskForBeerOrigin : Command
{
    public BeerId BeerId;
    
    public AskForBeerOrigin(BeerId aggregateId, Guid commitId) 
        : base(aggregateId, commitId)
    {
        BeerId = aggregateId;
    }
}