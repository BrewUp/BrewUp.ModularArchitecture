using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.Registries.ReadModel.Services;

public interface IPubService
{
    Task CreatePubAsync(PubId pubId, PubName pubName, CancellationToken cancellationToken);
    Task<PagedResult<PubJson>> GetPubsAsync(object o, int i, int i1, CancellationToken cancellationToken);
}