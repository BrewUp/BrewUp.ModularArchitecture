using BrewUp.Warehouses.Domain.Entities;

namespace BrewUp.Warehouses.Domain.Helpers;

public static class DomainHelpers
{
    public static IEnumerable<ProductionOrderRow> ToDomainEntities(
        this IEnumerable<Warehouses.SharedKernel.Dtos.ProductionOrderRow> dtos)
    {
        return dtos.Select(dto => ProductionOrderRow.Create(dto.BeerId, dto.BeerName, dto.Quantity));
    }
}