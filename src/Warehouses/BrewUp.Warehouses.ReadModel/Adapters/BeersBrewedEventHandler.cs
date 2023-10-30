using BrewUp.Shared.Messages;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;

namespace BrewUp.Warehouses.ReadModel.Adapters;

public sealed class BeersBrewedEventHandler : IntegrationEventHandlerAsync<BeersBrewed>
{
    private readonly IServiceBus _serviceBus;
    
    public BeersBrewedEventHandler(ILoggerFactory loggerFactory, IServiceBus serviceBus) : base(loggerFactory)
    {
        _serviceBus = serviceBus;
    }

    public override Task HandleAsync(BeersBrewed @event, CancellationToken cancellationToken = new ())
    {
        throw new NotImplementedException();
    }
}