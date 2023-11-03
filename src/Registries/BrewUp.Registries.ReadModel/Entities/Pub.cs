using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.Registries.ReadModel.Entities;

public class Pub : EntityBase
{
    public string PubName { get; private set; } = string.Empty;
    
    protected Pub()
    {}
    
    public static Pub CreatePub(PubId pubId, PubName pubName) => new(pubId.Value, pubName.Value);
    
    private Pub(Guid pubId, string pubName)
    {
        Id = pubId.ToString();
        PubName = pubName;
    }
    
    public PubJson ToJson() => new(new Guid(Id), PubName);
}