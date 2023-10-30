using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Warehouses.Domain.CommandHandlers;
using BrewUp.Warehouses.Messages.Commands;
using BrewUp.Warehouses.Messages.Events;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace BrewUp.Warehouses.Domain.Tests.Entities;

public class CreateBeerAvailabilitySuccessfully : CommandSpecification<CreateBeerAvailablity>
{
    private readonly BeerId _beerId = new(Guid.NewGuid());
    private readonly BeerName _beerName = new("BeerName");
    
    protected override IEnumerable<DomainEvent> Given()
    {
        yield break;
    }

    protected override CreateBeerAvailablity When()
    {
        return new CreateBeerAvailablity(_beerId, _beerName);
    }

    protected override ICommandHandlerAsync<CreateBeerAvailablity> OnHandler()
    {
        return new CreateBeerAvailabilityCommandHandlerAsync(Repository, new NullLoggerFactory());
    }

    protected override IEnumerable<DomainEvent> Expect()
    {
        yield return new BeerAvailabilityCreated(_beerId, _beerName);
    }
}