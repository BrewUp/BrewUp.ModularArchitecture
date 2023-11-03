using BrewUp.Registries.Facade.BindingModels;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.Entities;

namespace BrewUp.Registries.Facade;

public interface IRegistriesFacade
{
    Task<string> CreatePubsAsync(PubModel body, CancellationToken cancellationToken);
    Task<PagedResult<PubJson>> GetPubsAsync(CancellationToken cancellationToken);
    Task<string> CreateBeerAsync(BeerModel body, CancellationToken cancellationToken);
    Task<PagedResult<BeerJson>> GetBeersAsync(CancellationToken cancellationToken);
}