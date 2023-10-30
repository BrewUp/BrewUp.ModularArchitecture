using BrewUp.Shared.Messages;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;

namespace BrewUp.Warehouses.ReadModel.Adapters;

public sealed class BeersBrewedEventHandler : IntegrationEventHandlerAsync<BeersBrewed>
{
    private readonly IServiceBus _serviceBus;
    private readonly IBeerAvailabilityService _beerAvailabilityService;

    public BeersBrewedEventHandler(ILoggerFactory loggerFactory, IServiceBus serviceBus,
        IBeerAvailabilityService beerAvailabilityService) : base(loggerFactory)
    {
        _serviceBus = serviceBus;
        _beerAvailabilityService = beerAvailabilityService;
    }

    public override Task HandleAsync(BeersBrewed @event, CancellationToken cancellationToken = new ())
    {
        throw new NotImplementedException();
    }
}