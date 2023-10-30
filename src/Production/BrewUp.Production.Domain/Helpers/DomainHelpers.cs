using BrewUp.Production.Domain.Entities;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Production.Domain.Helpers;

public static class DomainHelpers
{
    public static IEnumerable<ProductionOrderRow> ToDomainEntities(
        this IEnumerable<Production.SharedKernel.Dtos.ProductionOrderRow> dtos)
    {
        return dtos.Select(dto => ProductionOrderRow.Create(dto.BeerId, dto.BeerName, dto.Quantity));
    }
    
    public static IEnumerable<Production.SharedKernel.Dtos.ProductionOrderRow> ToDtos(
        this IEnumerable<ProductionOrderRow> dtos)
    {
        return dtos.Select(dto => new Production.SharedKernel.Dtos.ProductionOrderRow(dto._beerId, dto._beerName, dto._quantity));
    }
}