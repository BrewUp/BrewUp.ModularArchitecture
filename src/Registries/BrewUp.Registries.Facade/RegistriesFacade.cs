using BrewUp.Registries.Facade.BindingModels;
using BrewUp.Registries.ReadModel.Services;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.Registries.Facade;

public sealed class RegistriesFacade : IRegistriesFacade
{
    private readonly IPubService _pubService;
    private readonly IBeerService _beerService;

    public RegistriesFacade(IPubService pubService, IBeerService beerService)
    {
        _pubService = pubService;
        _beerService = beerService;
    }

    public async Task<string> CreatePubsAsync(PubModel body, CancellationToken cancellationToken)
    {
        if (body.PubId.Equals(Guid.Empty))
            body = body with {PubId = Guid.NewGuid()};

        await _pubService.CreatePubAsync(new PubId(body.PubId), new PubName(body.PubName), cancellationToken);
        
        return body.PubId.ToString();
    }

    public async Task<PagedResult<PubJson>> GetPubsAsync(CancellationToken cancellationToken)
    {
        return await _pubService.GetPubsAsync(null, 0, 100, cancellationToken);
    }

    public async Task<string> CreateBeerAsync(BeerModel body, CancellationToken cancellationToken)
    {
        if (body.BeerId.Equals(Guid.Empty))
            body = body with {BeerId = Guid.NewGuid()};

        await _beerService.CreateBeerAsync(new BeerId(body.BeerId), new BeerName(body.BeerName),
            new BeerType(body.BeerType), cancellationToken);

        return body.BeerId.ToString();
    }

    public async Task<PagedResult<BeerJson>> GetBeersAsync(CancellationToken cancellationToken)
    {
        return await _beerService.GetBeersAsync(null, 0, 100, cancellationToken);
    }
}