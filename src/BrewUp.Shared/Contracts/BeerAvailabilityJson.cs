using BrewUp.Shared.Dtos;

namespace BrewUp.Shared.Contracts;

public class BeerAvailabilityJson
{
    public string BeerId { get; set; } = string.Empty;
    public string BeerName { get; set; } = string.Empty;
    
    public Availability Availability { get; set; } = new(0, string.Empty);
}