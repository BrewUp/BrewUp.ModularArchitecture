namespace BrewUp.Sales.SharedKernel.Dtos;

public record SalesOrderNumber(string Value)
{
    public static implicit operator string(SalesOrderNumber salesOrderNumber) => salesOrderNumber.Value;
}