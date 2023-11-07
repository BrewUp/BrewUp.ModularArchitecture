using BrewUp.Production.SharedKernel.DomainIds;
using BrewUp.Production.SharedKernel.Dtos;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Production.Messages.Events;

public sealed class ProductionOrderCreated_V2 : DomainEvent
{
	public readonly ProductionOrderId ProductionOrderId;
	public readonly ProductionOrderNumber ProductionOrderNumber;
	public readonly OrderDate OrderDate;
	public readonly IEnumerable<ProductionOrderRow> Rows;

	//Added the new field
	public readonly string CustomerNotes;


	public ProductionOrderCreated_V2(ProductionOrderId aggregateId, ProductionOrderNumber productionOrderNumber,
		OrderDate orderDate, string customerNotes, IEnumerable<ProductionOrderRow> rows) : base(aggregateId)
	{
		ProductionOrderId = aggregateId;
		ProductionOrderNumber = productionOrderNumber;

		OrderDate = orderDate;

		Rows = rows;
		CustomerNotes = customerNotes;
	}
}