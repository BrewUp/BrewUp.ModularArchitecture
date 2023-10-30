using BrewUp.Production.Domain.Entities;

namespace BrewUp.Production.Domain.Helpers;

public static class DomainHelpers
{
    public static IEnumerable<ProductionOrderRow> ToDomainEntities(
        this IEnumerable<Production.SharedKernel.Dtos.ProductionOrderRow> dtos)
    {
        return dtos.Select(dto => ProductionOrderRow.Create(dto.BeerId, dto.BeerName, dto.Quantity));
    }
}