using BrewUp.Sales.Domain.Entities;
using BrewUp.Sales.SharedKernel.Dtos;

namespace BrewUp.Sales.Domain.Helpers;

public static class DomainHelpers
{
    internal static IEnumerable<SalesOrderLine> ToDomainEntities(this IEnumerable<SalesOrderRowDto> dtos)
    {
        return dtos.Select(dto =>
            SalesOrderLine.CreateSalesOrderLine(dto.BeerId, dto.BeerName, dto.Quantity, dto.Price));
    }
    
    internal static IEnumerable<SalesOrderRowDto> ToDtos(this IEnumerable<SalesOrderLine> entities)
    {
        return entities.Select(entity =>
            new SalesOrderRowDto(entity._beerId, entity._beerName, entity._quantity, entity._price));
    }
}