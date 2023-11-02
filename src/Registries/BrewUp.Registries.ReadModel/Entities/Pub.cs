using BrewUp.Shared.Entities;

namespace BrewUp.Registries.ReadModel.Entities;

public class Pub : EntityBase
{
    public string PubName { get; private set; } = string.Empty;
    
    protected Pub()
    {
    }
    
}