﻿using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Warehouses.ReadModel.EventHandlers;

public sealed class BeerAvailabilityCreatedEventHandlerAsync : DomainEventHandlerAsync<BeerAvailabilityCreated>
{
    private readonly IBeerAvailabilityService _beerAvailabilityService;
    
    public BeerAvailabilityCreatedEventHandlerAsync(ILoggerFactory loggerFactory,
        IBeerAvailabilityService beerAvailabilityService) : base(loggerFactory)
    {
        _beerAvailabilityService = beerAvailabilityService;
    }

    public override Task HandleAsync(BeerAvailabilityCreated @event, CancellationToken cancellationToken = new ())
    {
        throw new NotImplementedException();
    }
}