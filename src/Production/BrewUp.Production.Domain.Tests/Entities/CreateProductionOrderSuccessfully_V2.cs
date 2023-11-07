using BrewUp.Production.Domain.CommandHandlers;
using BrewUp.Production.Messages.Commands;
using BrewUp.Production.Messages.Events;
using BrewUp.Production.SharedKernel.DomainIds;
using BrewUp.Production.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace BrewUp.Production.Domain.Tests.Entities;

public sealed class CreateProductionOrderSuccessfully_V2 : CommandSpecification<CreateProductionOrder>
{
	private readonly ProductionOrderId _productionOrderId = new(Guid.NewGuid());
	private readonly ProductionOrderNumber _productionOrderNumber = new("20231108-01");
	private readonly OrderDate _orderDate = new(DateTime.UtcNow);
	private readonly string _customerNotes = "Customer notes";

	private readonly IEnumerable<ProductionOrderRow> _rows = Enumerable.Empty<ProductionOrderRow>();

	public CreateProductionOrderSuccessfully_V2()
	{
		_rows = _rows.Concat(new List<ProductionOrderRow>
		{
			new(new BeerId(Guid.NewGuid()), new BeerName("Beer 1"), new Quantity(10, "NR"))
		});
	}

	protected override IEnumerable<DomainEvent> Given()
	{
		yield break;
	}

	protected override CreateProductionOrder When()
	{
		return new CreateProductionOrder(_productionOrderId, _productionOrderNumber, _orderDate, _customerNotes, _rows);
	}

	protected override ICommandHandlerAsync<CreateProductionOrder> OnHandler()
	{
		return new CreateProductionOrderCommandHandler(Repository, new NullLoggerFactory());
	}

	protected override IEnumerable<DomainEvent> Expect()
	{
		yield return new ProductionOrderCreated_V2(_productionOrderId, _productionOrderNumber, _orderDate, _customerNotes,
			_rows);
	}
}