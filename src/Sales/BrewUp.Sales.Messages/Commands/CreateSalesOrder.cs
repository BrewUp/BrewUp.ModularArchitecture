using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Sales.Messages.Commands;

public sealed class CreateSalesOrder : Command
{
    public readonly SalesOrderId SalesOrderId;
    public readonly CustomerId CustomerId;
    public readonly OrderDate OrderDate;

    public readonly IEnumerable<SalesOrderLineDto> Lines;

    public CreateSalesOrder(SalesOrderId aggregateId, CustomerId customerId, OrderDate orderDate,
        IEnumerable<SalesOrderLineDto> lines) : base(aggregateId)
    {
        SalesOrderId = aggregateId;
        CustomerId = customerId;
        OrderDate = orderDate;

        Lines = lines;
    }
}