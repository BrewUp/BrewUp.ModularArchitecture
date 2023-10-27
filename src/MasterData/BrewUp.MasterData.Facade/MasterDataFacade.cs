using BrewUp.MasterData.Facade.BindingModels;
using BrewUp.MasterData.ReadModel.Services;
using BrewUp.Shared.BindingModels;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.MasterData.Facade;

public sealed class MasterDataFacade : IMasterDataFacade
{
    private readonly IPubService _pubService;

    public MasterDataFacade(IPubService pubService)
    {
        _pubService = pubService;
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
}