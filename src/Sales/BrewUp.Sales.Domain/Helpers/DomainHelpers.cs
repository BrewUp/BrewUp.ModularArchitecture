using BrewUp.Sales.Domain.Entities;
using BrewUp.Sales.SharedKernel.Dtos;

namespace BrewUp.Sales.Domain.Helpers;

public static class DomainHelpers
{
    internal static IEnumerable<SalesOrderLine> ToDomainEntities(this IEnumerable<SalesOrderLineDto> dtos)
    {
        return dtos.Select(dto =>
            SalesOrderLine.CreateSalesOrderLine(dto.ProductId, dto.ProductName, dto.Quantity, dto.Price));
    }
}