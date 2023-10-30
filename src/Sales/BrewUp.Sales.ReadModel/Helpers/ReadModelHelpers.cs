using BrewUp.Sales.ReadModel.Entities;
using BrewUp.Sales.SharedKernel.Dtos;

namespace BrewUp.Sales.ReadModel.Helpers;

public static class ReadModelHelpers
{
    public static IEnumerable<SalesOrderRow> ToReadModelEntities(this IEnumerable<SalesOrderRowDto> dtos)
    {
        return dtos.Select(dto =>
            new SalesOrderRow
            {
                BeerId = dto.BeerId.Value.ToString(),
                BeerName = dto.BeerName.Value,
                Quantity = dto.Quantity,
                Price = dto.Price
            });
    }
}