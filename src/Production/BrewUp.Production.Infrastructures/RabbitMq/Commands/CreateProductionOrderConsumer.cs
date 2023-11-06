using BrewUp.Production.Domain.CommandHandlers;
using BrewUp.Production.Messages.Commands;
using BrewUp.Shared.Messages.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Production.Infrastructures.RabbitMq.Commands;

public sealed class CreateProductionOrderConsumer : CommandConsumerBase<CreateProductionOrder>
{
    protected override ICommandHandlerAsync<CreateProductionOrder> HandlerAsync { get; }
    
    public CreateProductionOrderConsumer(IRepository repository, IMufloneConnectionFactory connectionFactory,
        ILoggerFactory loggerFactory) : base(repository, connectionFactory, loggerFactory)
    {
        HandlerAsync = new CreateProductionOrderCommandHandler(repository, loggerFactory);
    }
}