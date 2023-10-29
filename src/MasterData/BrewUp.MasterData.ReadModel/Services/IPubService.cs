using System.Linq.Expressions;
using BrewUp.MasterData.ReadModel.Entities;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.MasterData.ReadModel.Services;

public interface IPubService
{
    Task<string> CreatePubAsync(PubId pubId, PubName pubName, CancellationToken cancellationToken);

    Task<PagedResult<PubJson>> GetPubsAsync(Expression<Func<Pub, bool>>? query, int page, int pageSize,
        CancellationToken cancellationToken);
}