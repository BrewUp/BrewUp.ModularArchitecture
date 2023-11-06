using BrewUp.Production.Domain.Entities;

namespace BrewUp.Production.Domain.Helpers;

public static class DomainHelpers
{
    public static IEnumerable<ProductionOrderRow> ToDomainEntities(
        this IEnumerable<Shared.Dtos.ProductionOrderRow> dtos)
    {
        return dtos.Select(dto => ProductionOrderRow.Create(dto.BeerId, dto.BeerName, dto.Quantity));
    }
    
    public static IEnumerable<Shared.Dtos.ProductionOrderRow> ToDtos(
        this IEnumerable<ProductionOrderRow> dtos)
    {
        return dtos.Select(dto => new Shared.Dtos.ProductionOrderRow(dto._beerId, dto._beerName, dto._quantity));
    }
}