using BrewUp.Shared.DomainIds;
using Muflone.Messages.Commands;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class AskForBeerOrigin : Command
{
    public BeerId Beer;
    
    public AskForBeerOrigin(BeerId aggregateId, Guid commitId) 
        : base(aggregateId, commitId)
    {
        Beer = aggregateId;
    }
}