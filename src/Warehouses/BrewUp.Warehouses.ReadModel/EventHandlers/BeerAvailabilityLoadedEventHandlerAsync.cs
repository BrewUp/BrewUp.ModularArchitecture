using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Warehouses.ReadModel.EventHandlers;

public sealed class BeerAvailabilityLoadedEventHandlerAsync : DomainEventHandlerAsync<BeerAvailabilityLoaded>
{
    private readonly IBeerAvailabilityService _beerAvailabilityService;
    public BeerAvailabilityLoadedEventHandlerAsync(ILoggerFactory loggerFactory,
        IBeerAvailabilityService beerAvailabilityService) : base(loggerFactory)
    {
        _beerAvailabilityService = beerAvailabilityService;
    }

    public override async Task HandleAsync(BeerAvailabilityLoaded @event, CancellationToken cancellationToken = new ())
    {
        await _beerAvailabilityService.LoadBeerAvailabilityAsync(@event.BeerId, @event.Availability, cancellationToken);
    }
}