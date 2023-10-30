﻿using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Warehouses.Domain.CommandHandlers;
using BrewUp.Warehouses.Messages.Commands;
using BrewUp.Warehouses.Messages.Events;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace BrewUp.Warehouses.Domain.Tests.Entities;

public sealed class LoadBeerAvailabilitySuccessfully : CommandSpecification<LoadBeerAvailability>
{
    private readonly BeerId _beerId = new(Guid.NewGuid());
    private readonly BeerName _beerName = new("BeerName");
    
    private readonly Availability _availability = new(10, "Lt");
    
    protected override IEnumerable<DomainEvent> Given()
    {
        yield return new BeerAvailabilityCreated(_beerId, _beerName);
    }

    protected override LoadBeerAvailability When()
    {
        return new LoadBeerAvailability(_beerId, _availability);
    }

    protected override ICommandHandlerAsync<LoadBeerAvailability> OnHandler()
    {
        return new LoadBeerAvailabilityCommandHandlerAsync(Repository, new NullLoggerFactory());
    }

    protected override IEnumerable<DomainEvent> Expect()
    {
        yield return new BeerAvailabilityLoaded(_beerId, _availability);
    }
}