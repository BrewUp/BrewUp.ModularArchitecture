using BrewUp.MasterData.Facade.BindingModels;
using BrewUp.Shared.BindingModels;
using BrewUp.Shared.Entities;

namespace BrewUp.MasterData.Facade;

public interface IMasterDataFacade
{
    Task<string> CreatePubsAsync(PubModel body, CancellationToken cancellationToken);
    Task<PagedResult<PubJson>> GetPubsAsync(CancellationToken cancellationToken);
}