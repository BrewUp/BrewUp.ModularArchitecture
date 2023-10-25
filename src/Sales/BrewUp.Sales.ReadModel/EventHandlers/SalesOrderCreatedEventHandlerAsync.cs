using BrewUp.Sales.Messages.Events;
using Microsoft.Extensions.Logging;

namespace BrewUp.Sales.ReadModel.EventHandlers;

public sealed class SalesOrderCreatedEventHandlerAsync : DomainEventHandlerBase<SalesOrderCreated>
{
    public SalesOrderCreatedEventHandlerAsync(ILoggerFactory loggerFactory) : base(loggerFactory)
    {
    }

    public override async Task HandleAsync(SalesOrderCreated @event, CancellationToken cancellationToken = new ())
    {
        throw new NotImplementedException();
    }
}