using BrewUp.Sales.Domain.CommandHandlers;
using BrewUp.Sales.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Sales.Infrastructures.RabbitMq.Commands;

public sealed class CompleteSalesOrderConsumer : CommandConsumerBase<CompleteSalesOrder>
{
    protected override ICommandHandlerAsync<CompleteSalesOrder> HandlerAsync { get; }
    
    public CompleteSalesOrderConsumer(IRepository repository, IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) : base(repository, connectionFactory, loggerFactory)
    {
        HandlerAsync = new CompleteSalesOrderCommandHandler(repository, loggerFactory);
    }
}