using BrewUp.Sales.Domain.CommandHandlers;
using BrewUp.Sales.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Sales.Infrastructures.RabbitMq.Commands;

public sealed class CreateSalesOrderConsumer : CommandConsumerBase<CreateSalesOrder>
{
    protected override ICommandHandlerAsync<CreateSalesOrder> HandlerAsync { get; }
    
    public CreateSalesOrderConsumer(IRepository repository,
        IMufloneConnectionFactory connectionFactory,
        ILoggerFactory loggerFactory) : base(repository, connectionFactory, loggerFactory)
    {
        HandlerAsync = new CreateSalesOrderCommandHandlerAsync(repository, loggerFactory);
    }
}