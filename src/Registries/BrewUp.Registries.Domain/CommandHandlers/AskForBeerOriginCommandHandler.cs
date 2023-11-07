using BrewUp.Registries.ReadModel.Entities;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Messages.Sagas;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Persistence;

namespace BrewUp.Registries.Domain.CommandHandlers;

public sealed class AskForBeerOriginCommandHandler : CommandHandlerBaseAsync<AskForBeerOrigin>
{
    private readonly IQueries<Beer> _queries;
    private readonly IEventBus _eventBus;

    public AskForBeerOriginCommandHandler(IRepository repository, ILoggerFactory loggerFactory, IQueries<Beer> queries,
        IEventBus eventBus) : base(repository, loggerFactory)
    {
        _queries = queries;
        _eventBus = eventBus;
    }

    public override async Task ProcessCommand(AskForBeerOrigin command, CancellationToken cancellationToken = default)
    {
        var beer = await _queries.GetByIdAsync(command.BeerId.Value.ToString(), cancellationToken);
        
        var homeBrewed = string.IsNullOrEmpty(beer.Id)
            ? new HomeBrewed(false)
            : new HomeBrewed(beer.HomeBrewed);
        
        BeerOriginDiscovered beerOriginDiscovered = new(command.BeerId, command.MessageId, homeBrewed);
        await _eventBus.PublishAsync(beerOriginDiscovered, cancellationToken);
    }
}